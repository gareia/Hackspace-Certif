using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Application.Service.Interfaces;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Infrastructure.Repository.Interfaces;
using ToDoAPI.Infrastructure.UnitOfWork.Interfaces;

namespace ToDoAPI.Application.Service.Classes
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, IUnitOfWork unitOfWork)
        {
            _toDoItemRepository = toDoItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            return await _toDoItemRepository.ListAsync();
        }
    }
}
