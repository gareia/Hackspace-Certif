using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Infrastructure.Repository.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
        Task AddAsync(ToDoItem item);
        Task<ToDoItem> FindByIdAsync(long id);
    }
}
