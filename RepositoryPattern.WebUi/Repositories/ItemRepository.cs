using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WebUi.Data;
using RepositoryPattern.WebUi.Models;
using RepositoryPattern.WebUi.Repositories.Interfaces;

namespace RepositoryPattern.WebUi.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _context.Items!.ToListAsync(); // ToListAsync is from EntityFrameworkCore
            return items ?? new List<Item>();                // Return an empty list if items is null
        }

        // Get item by ID
        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Items!.FindAsync(id);
            return item ?? new Item();                       // Return a new Item if not found (or handle as needed)
        }

        // Add a new item
        public async Task AddAsync(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _context.Items!.AddAsync(item);            // Used (!) null-forgiving operator to suppress null reference warning
            await _context.SaveChangesAsync();
        }

        // Update an existing item
        public async Task UpdateAsync(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var existingItem = await _context.Items!.FindAsync(item.Id); // Used (!) null-forgiving operator to suppress null reference warning

            if (existingItem != null)
            {
                existingItem.Name = item.Name;                           // Update properties as needed
                existingItem.Description = item.Description;             // Update properties as needed
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the item does not exist (optional)
                throw new KeyNotFoundException($"Item with ID {item.Id} not found.");
            }
        }

        // Delete an item by ID
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Items!.FindAsync(id);              // Used (!) null-forgiving operator to suppress null reference warning
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the item does not exist (optional)
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
        }
    }
}
