﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemDTO
    {
        [Key]
        public long Id { get; set; } //int
        [Required]
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
