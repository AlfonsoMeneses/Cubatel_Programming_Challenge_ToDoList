using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Exceptions
{
    public  class ToDoListItemException:Exception
    {
        public ToDoListItemException() { }

        public ToDoListItemException(string message) : base(message) { }
    }
}
