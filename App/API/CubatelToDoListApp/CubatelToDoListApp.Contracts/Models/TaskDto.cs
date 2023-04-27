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

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
