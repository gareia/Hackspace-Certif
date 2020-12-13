using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Infrastructure.Repository.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
        Task AddAsync(ToDoItem item);
        Task<ToDoItem> FindByIdAsync(long id);
        void Remove(long id);
        ToDoItem Update(ToDoItem item, ToDoItem newItem);

    }
}
