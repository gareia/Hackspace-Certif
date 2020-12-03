using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Application.Service.Communication;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Application.Service.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
        Task<ToDoItemResponse> AddAsync(ToDoItem item);
    }
}
