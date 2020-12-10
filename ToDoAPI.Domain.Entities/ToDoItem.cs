using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Domain.Entities
{
    public class ToDoItem
    {
        [Key]
        public long Id { get; set; } //int
        [Required]
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LimitDate { get; set; }
    }
}
