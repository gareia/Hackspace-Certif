using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Infrastructure.Repository.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
        Task AddAsync(ToDoItem item);
        Task<ToDoItem> FindByIdAsync(long id);
        void Remove(ToDoItem item);
        ToDoItem Update(ToDoItem item, ToDoItem newItem);

    }
}
