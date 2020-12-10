using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
using ToDoAPI.Application.Service.Interfaces;
using ToDoAPI.Crosscuting.Extensions;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Distributed.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly IMapper _mapper;

        public ToDoItemController(IToDoItemService toDoItemService, IMapper mapper)
        {
            _toDoItemService = toDoItemService;
            _mapper = mapper;
        }

        // GET: api/ToDoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetAll()
        {   
            var items = await _toDoItemService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ToDoItem>, IEnumerable<ToDoItemDTO>>(items);
            return Ok(resources);
        }

        // POST: api/ToDoItem
        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> Post([FromBody] ToDoItemCreationDTO resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages()); 

            var item = _mapper.Map<ToDoItemCreationDTO, ToDoItem>(resource);
            var result = await _toDoItemService.AddAsync(item);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<ToDoItem,ToDoItemDTO>(result.Resource);
            return Ok(itemResource);
        }

        // GET: api/ToDoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetById(long id)
        {
            var result = await _toDoItemService.FindByIdAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);

            var itemResource = _mapper.Map<ToDoItem, ToDoItemDTO>(result.Resource);

            return Ok(itemResource);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItemDTO>> Delete(long id)
        {
            var result = await _toDoItemService.RemoveAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);

            var itemResource = _mapper.Map<ToDoItem, ToDoItemDTO>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(long id, [FromBody] ToDoItemModificationDTO newItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var newest = _mapper.Map<ToDoItemModificationDTO, ToDoItem>(newItem);
            var result = await _toDoItemService.UpdateAsync(id, newest);

            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);

            var itemResource = _mapper.Map<ToDoItem, ToDoItemDTO>(result.Resource);
            return Ok(itemResource);
        }
        
    }
}
