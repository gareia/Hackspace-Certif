using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Infrastructure.Connections.Contexts;
using ToDoAPI.Infrastructure.Repository.Interfaces;

namespace ToDoAPI.Infrastructure.Repository.Classes
{
    public class ToDoItemRepository: BaseRepository, IToDoItemRepository
    {
        public ToDoItemRepository(AppDbContext context): base(context)
        {

        }

        public async Task AddAsync(ToDoItem item)
        {
             await _context.ToDoItems.AddAsync(item);
        }

        public void Remove(ToDoItem item)
        {
            _context.Remove(item);
        }

        public async Task<ToDoItem> FindByIdAsync(long id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            return await _context.ToDoItems.ToListAsync();

        }

        public ToDoItem Update(ToDoItem item, ToDoItem newItem)
        {
            if (newItem.Name != null)
                item.Name = newItem.Name;
            if (newItem.Completed)
                item.Completed = newItem.Completed;
            if (newItem.LimitDate != null)
                item.LimitDate = newItem.LimitDate;

            _context.ToDoItems.Update(item);
            return item;
        }
    }
}
