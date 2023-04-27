using CubatelToDoListApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Contracts.Services
{
    public interface IToDoListItemService
    {
        TaskItemDto AddItemToAList(int taskId, string name, string description);

        TaskItemDto RemoveItem(int id);

        TaskItemDto EditItem(int id, TaskItemDto item);

        TaskItemDto CompleteItem(int id);

        TaskItemDto MoveItemToATask(int id, int taskId);
    }
}
