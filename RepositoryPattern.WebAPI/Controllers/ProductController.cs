using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.WebAPI.Models;

namespace RepositoryPattern.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new Product
            {
                ProductId = 10,
                ProductName = "Brush",
                ProdutPrice = 50
            });
        }
    }
}
