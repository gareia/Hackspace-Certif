using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
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

                if (item == null)
                    return new ToDoItemResponse($"Item with id: {id} was not found", 404);

                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while finding todoitem with id: {id} ===> {e.Message}", 500);
            }
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            return await _toDoItemRepository.ListAsync();
        }

        public async Task<ToDoItemResponse> RemoveAsync(long id)
        {
            var item = await _toDoItemRepository.FindByIdAsync(id);

            if (item == null)
                return new ToDoItemResponse($"Item with id: {id} was not found", 404);

            try
            {
                _toDoItemRepository.Remove(item);
                await _unitOfWork.CompleteAsync();
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while removing todoitem with id: {id} ---> {e.Message}", 500);
            }

        }

        public async Task<ToDoItemResponse> UpdateAsync(long id, ToDoItemModificationDTO newItem)
        {
            var item = await _toDoItemRepository.FindByIdAsync(id);

            if (item == null)
                return new ToDoItemResponse($"Item with id: {id} was not found", 404);

            if (item.Completed)
                return new ToDoItemResponse($"Item with id: {id} is already completed", 400);

            try
            {
                ToDoItem updatedItem = _toDoItemRepository.Update(item, newItem);
                await _unitOfWork.CompleteAsync();
                return new ToDoItemResponse(updatedItem);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while updating todoitem with id: {id} ---> {e.Message}", 500);
            }
        }
    }
}
