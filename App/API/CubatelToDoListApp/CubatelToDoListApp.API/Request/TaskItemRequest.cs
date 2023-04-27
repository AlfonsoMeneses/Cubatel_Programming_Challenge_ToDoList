using System.ComponentModel.DataAnnotations;

namespace CubatelToDoListApp.API.Request
{
    public class TaskItemRequest
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskItemRequest()
        {
            TaskId = -1;
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
