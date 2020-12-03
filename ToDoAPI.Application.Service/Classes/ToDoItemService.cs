using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.Application.Service.Communication;
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

        public async Task<ToDoItemResponse> AddAsync(ToDoItem item)
        {
            try
            {
                await _toDoItemRepository.AddAsync(item);
                await _unitOfWork.CompleteAsync();
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                //warn:
                return new ToDoItemResponse($"An exception ocurred while adding todoitem ===> {e.Message}");
            }
        }

        public async Task<ToDoItemResponse> FindByIdAsync(long id)
        {
            try
            {
                var item = await _toDoItemRepository.FindByIdAsync(id);
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while finding todoitem with id: {id} ===> {e.Message}");
            }
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            return await _toDoItemRepository.ListAsync();
        }


    }
}
