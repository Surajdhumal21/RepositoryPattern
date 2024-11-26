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

        // GET: Items
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
        }

        // GET: Items/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: Items/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost("Create")]
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

        // GET: Items/Edit/{id}
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Items/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Items/Delete/{id}
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
