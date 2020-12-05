using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemModificationDTO
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}
