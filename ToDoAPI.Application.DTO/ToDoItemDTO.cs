using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemDTO
    {
        public long Id { get; set; } //int
        public string Name { get; set; }
        public bool Completed { get; set; } = false;

        //TODO: AQUI FALTA!!
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
