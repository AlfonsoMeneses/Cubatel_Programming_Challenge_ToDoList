using System.ComponentModel.DataAnnotations;

namespace CubatelToDoListApp.API.Request
{
    public class TaskRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskRequest()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
