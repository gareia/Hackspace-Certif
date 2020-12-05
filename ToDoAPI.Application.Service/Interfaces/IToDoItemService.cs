using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
using ToDoAPI.Application.Service.Communication;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Application.Service.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
        Task<ToDoItemResponse> AddAsync(ToDoItem item);
        Task<ToDoItemResponse> FindByIdAsync(long id);
        Task<ToDoItemResponse> RemoveAsync(long id);
        Task<ToDoItemResponse> UpdateAsync(long id, ToDoItemModificationDTO newItem);
        
    }
}
