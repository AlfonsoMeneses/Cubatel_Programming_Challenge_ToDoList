using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Exceptions
{
    public class ToDoListException: Exception
    {
        public ToDoListException() { }

        public ToDoListException(string message) : base(message) { }
    }
}
