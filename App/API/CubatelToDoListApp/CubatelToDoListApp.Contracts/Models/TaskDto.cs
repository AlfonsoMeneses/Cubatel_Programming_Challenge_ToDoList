using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Models
{
    public class TaskDto
    {
        public int IdTask { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<TaskItemDto> Items { get; set; }

        public TaskDto() {
            Name = string.Empty;
            Description = string.Empty;
            Items = new List<TaskItemDto>();
        }    

        public TaskDto(int idTask, string name, string description)
        {
            IdTask = idTask;
            Name = name;
            Description = description;

            Items = new List<TaskItemDto>();
        }
    }
}
