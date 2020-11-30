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

        // GET: api/ToDoItem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ToDoItem
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ToDoItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
