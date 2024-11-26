using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.WebUi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between $0.01 and $10,000.")]
        [Column(TypeName = "decimal(18,2)")] // EF Core specific for decimal precision
        [Display(Name = "Price (USD)")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        [Display(Name = "Stock Quantity")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public string? Category { get; set; }

        [Display(Name = "Product Image URL")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Added On")]
        [Required(ErrorMessage = "Date Added is required.")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [Display(Name = "Last Updated On")]
        public DateTime? LastUpdatedOn { get; set; }

        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "SKU must be alphanumeric and uppercase.")]
        [StringLength(20, ErrorMessage = "SKU cannot exceed 20 characters.")]
        [Display(Name = "Stock Keeping Unit (SKU)")]
        public string? SKU { get; set; }

        [Required(ErrorMessage = "Manufacturer name is required.")]
        [StringLength(100, ErrorMessage = "Manufacturer name cannot exceed 100 characters.")]
        [Display(Name = "Manufacturer")]
        public string? Manufacturer { get; set; }

        [ConcurrencyCheck]
        [Display(Name = "Concurrency Token")]
        public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();
    }
}
