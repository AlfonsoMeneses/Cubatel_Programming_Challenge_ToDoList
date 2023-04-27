using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Models
{
    public class TaskItemDto
    {
        public int IdItem { get; set; }

        public int? TaskId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public short? IsCompleted { get; set; }
    }
}
