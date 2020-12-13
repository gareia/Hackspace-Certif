using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly ILogger _logger;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, IUnitOfWork unitOfWork, ILogger<ToDoItemService> logger)
        {
            _toDoItemRepository = toDoItemRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ToDoItemResponse> AddAsync(ToDoItem item)
        {
            try
            {
                if((item.LimitDate != DateTime.MinValue) && (item.LimitDate <= DateTime.Now))
                    return new ToDoItemResponse($"LimitDate should be greater than current datetime");

                await _toDoItemRepository.AddAsync(item);
                //await _unitOfWork.CompleteAsync();
                _logger.LogInformation("Item added successfully");
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                _logger.LogWarning("An exception ocurred while adding todoitem");
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

                _logger.LogInformation("Item found successfully");
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while finding todoitem with id: {id} ===> {e.Message}", 500);
            }
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            _logger.LogInformation("Calling items list");
            return await _toDoItemRepository.ListAsync();
        }

        public async Task<ToDoItemResponse> RemoveAsync(long id)
        {
            var item = await _toDoItemRepository.FindByIdAsync(id);

            if (item == null)
                return new ToDoItemResponse($"Item with id: {id} was not found", 404);

            try
            {
                _toDoItemRepository.Remove(id);
                //await _unitOfWork.CompleteAsync();
                _logger.LogInformation("Item removed successfully");
                return new ToDoItemResponse(item);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while removing todoitem with id: {id} ---> {e.Message}", 500);
            }

        }

        public async Task<ToDoItemResponse> UpdateAsync(long id, ToDoItem newItem)
        {
            if ((newItem.LimitDate != DateTime.MinValue) && (newItem.LimitDate <= DateTime.Now))
                return new ToDoItemResponse($"LimitDate should be greater than current datetime");

            var item = await _toDoItemRepository.FindByIdAsync(id);

            if (item == null)
                return new ToDoItemResponse($"Item with id: {id} was not found", 404);

            if (item.Completed)
                return new ToDoItemResponse($"Item with id: {id} is already completed", 400);

            try
            {
                ToDoItem updatedItem = _toDoItemRepository.Update(item, newItem);
                //await _unitOfWork.CompleteAsync();
                _logger.LogInformation("Item updated successfully");
                return new ToDoItemResponse(updatedItem);
            }
            catch(Exception e)
            {
                return new ToDoItemResponse($"An exception ocurred while updating todoitem with id: {id} ---> {e.Message}", 500);
            }
        }
    }
}
