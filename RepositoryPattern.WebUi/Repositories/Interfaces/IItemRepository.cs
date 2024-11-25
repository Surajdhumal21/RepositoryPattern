using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.WebUi.Models;

namespace RepositoryPattern.WebUi.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetAllAsync();
        public Task<Item> GetByIdAsync(int id);
        public Task AddAsync(Item item);
        public Task UpdateAsync(Item item);
        public Task DeleteAsync(int id);
    }
}
