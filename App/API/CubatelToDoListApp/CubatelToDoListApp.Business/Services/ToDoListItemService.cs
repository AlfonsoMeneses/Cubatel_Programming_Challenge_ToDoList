using AutoMapper;
using CubatelToDoListApp.Contracts.Exceptions;
using CubatelToDoListApp.Contracts.Models;
using CubatelToDoListApp.Contracts.Services;
using CubatelToDoListApp.DataService;
using CubatelToDoListApp.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Business.Services
{
    public class ToDoListItemService : IToDoListItemService
    {
        private CubatelMySQLContext _db;
        private readonly IMapper _mapper;

        public ToDoListItemService(CubatelMySQLContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public TaskItemDto AddItemToAList(int taskId, string name, string description)
        {
            var task = _db.Tasks.FirstOrDefault(task => task.IdTask == taskId);

            if (task == null)
            {
                throw new ToDoListItemException("There's no Task to add this item");
            }

            if (name == null || name.Trim().Equals(string.Empty))
            {
                throw new ToDoListItemException("Name is missing");
            }

            var newItem = new Item
            {
                TaskId = taskId,
                Name = name,
                Description = description,
                IsCompleted = 0
            };

            _db.Add(newItem);
            _db.SaveChanges();

            return _mapper.Map<TaskItemDto>(newItem);

        }

        public TaskItemDto RemoveItem(int id)
        {
            var item = ValidateIdItem(id);

            _db.Remove(item);

            _db.SaveChanges();

            return _mapper.Map<TaskItemDto>(item);
        }

        public TaskItemDto EditItem(int id, TaskItemDto itemToEdit)
        {
            var item = ValidateIdItem(id);

            item.Name = itemToEdit.Name;
            item.Description = itemToEdit.Description;

            _db.Update(item);
            _db.SaveChanges();

            return _mapper.Map<TaskItemDto>(item);

        }

        public TaskItemDto CompleteItem(int id)
        {
            var item = ValidateIdItem(id);

            item.IsCompleted = 1;

            _db.Update(item);
            _db.SaveChanges();

            return _mapper.Map<TaskItemDto>(item);
        }

        public TaskItemDto MoveItemToATask(int id, int taskId)
        {
            var task = _db.Tasks.FirstOrDefault(task => task.IdTask == taskId);

            if (task == null)
            {
                throw new ToDoListItemException("There's no Task to add this item");
            }

            var item = ValidateIdItem(id);

            item.TaskId = taskId;

            _db.Update(item);
            _db.SaveChanges();

            return _mapper.Map<TaskItemDto>(item);
        }

        private Item ValidateIdItem(int id)
        {
            var item = _db.Items.FirstOrDefault(item => item.IdItem == id);

            if (item == null)
            {
                throw new ToDoListItemException("This item doesnt exist");
            }

            return item;
        }
    }
}
