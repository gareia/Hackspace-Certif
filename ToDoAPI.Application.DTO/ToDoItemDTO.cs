using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemDTO
    {
        [Key]
        public long Id { get; set; } //int
        [Required]
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string CreatedAt { get; set; }
        public string LimitDate { get; set; }

    }
}
