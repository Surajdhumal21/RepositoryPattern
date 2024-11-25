using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.WebUi.Models;
using RepositoryPattern.WebUi.Repositories.Interfaces;

namespace RepositoryPattern.WebUi.Controllers
{
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemRepository _repository;


        public ItemsController(ILogger<ItemsController> logger, IItemRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }

        [HttpGet("create")]
        public IActionResult Create() => View();

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // Implement Edit and Delete actions similarly...

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
