using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WebUi.Data;
using RepositoryPattern.WebUi.Repositories;
using RepositoryPattern.WebUi.Repositories.Interfaces;

namespace RepositoryPattern.WebUi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ApplicationDbContext>(objects =>
            objects.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register repository and its implementation
        builder.Services.AddScoped<IItemRepository, ItemRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
