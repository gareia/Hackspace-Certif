using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            return await _context.ToDoItems.ToListAsync();

        }
    }
}
