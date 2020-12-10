using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(19)]
        public string LimitDate { get; set; }
    }
}
