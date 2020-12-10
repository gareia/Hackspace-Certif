using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Application.DTO
{
    public class ToDoItemModificationDTO
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        [MaxLength(19)]
        public string LimitDate { get; set; }
    }
}
