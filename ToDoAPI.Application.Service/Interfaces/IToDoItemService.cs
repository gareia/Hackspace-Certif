using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Application.Service.Interfaces
{
    public interface IToDoItemService
    {
        Task<IEnumerable<ToDoItem>> ListAsync();
    }
}
