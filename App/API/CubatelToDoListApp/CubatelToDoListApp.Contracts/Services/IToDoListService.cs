using CubatelToDoListApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Services
{
    public interface IToDoListService
    {
        IList<TaskDto> GetAllTasks();
        TaskDto CreateTask(string name, string description);
        TaskDto EditTask(int id, TaskDto task);
        TaskDto DeleteTask(int id);
        TaskDto GetTaskItems(int id);
    }
}
