using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
