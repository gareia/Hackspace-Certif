using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Application.DTO;
using ToDoAPI.Application.Service.Interfaces;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Crosscuting.Extensions;


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
        public async Task<ActionResult<ToDoItemDTO>> Post([FromBody] ToDoItemCreationDTO resource)//
        {
            //Add modelstate EXTENSION Y AÑADIR AQUI ABAJITO

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

        // PUT: api/ToDoItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        
    }
}
