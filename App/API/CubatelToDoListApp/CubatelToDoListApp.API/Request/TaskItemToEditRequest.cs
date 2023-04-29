using System.ComponentModel.DataAnnotations;

namespace CubatelToDoListApp.API.Request
{
    public class TaskItemToEditRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskItemToEditRequest()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
