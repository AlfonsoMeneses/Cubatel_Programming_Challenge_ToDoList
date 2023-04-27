﻿using AutoMapper;
using CubatelToDoListApp.Contracts.Exceptions;
using CubatelToDoListApp.Contracts.Models;
using CubatelToDoListApp.Contracts.Services;
using CubatelToDoListApp.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Business.Services
{
    public class ToDoListService : IToDoListService
    {
        private CubatelMySQLContext _db;
        private readonly IMapper _mapper;

        public ToDoListService(CubatelMySQLContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public TaskDto CreateTask(string name, string description)
        {
            if (name == null || name.Trim().Equals(string.Empty))
            {
                throw new ToDoListException("Name is missing");
            }
            var newTask = new DataService.Entities.Task
            {
                Name = name,
                Description = description
            };

            _db.Tasks.Add(newTask);
            _db.SaveChanges();

            return _mapper.Map<TaskDto>(newTask);
        }

        public IList<TaskDto> GetAllTasks()
        {
            var lst = _db.Tasks.ToList();

            var lstTask = new List<TaskDto>();

            foreach (var item in lst)
            {
                lstTask.Add(_mapper.Map<TaskDto>(item));
            }

            return lstTask;
        }

        public TaskDto EditTask(int id, TaskDto task)
        {
            var taskToEdit = this.ValidateIdTask(id);

            taskToEdit.Name = task.Name;
            taskToEdit.Description = task.Description;

            _db.Tasks.Update(taskToEdit);
            _db.SaveChanges();

            return _mapper.Map<TaskDto>(taskToEdit);
        }

        public TaskDto DeleteTask(int id)
        {
            var taskToDelete = this.ValidateIdTask(id);

            _db.Tasks.Remove(taskToDelete);

            _db.SaveChanges();

            return _mapper.Map<TaskDto>(taskToDelete);
        }

        public IList<TaskItemDto> GetTaskItems(int id)
        {
            var task = ValidateIdTask(id);

            var lst = _db.Items.Where(item => item.TaskId == id).ToList();

            var lstTaskItems = new List<TaskItemDto>();

            foreach (var item in lst)
            {
                lstTaskItems.Add(_mapper.Map<TaskItemDto>(item));
            }

            return lstTaskItems;
        }

        private DataService.Entities.Task ValidateIdTask(int id)
        {
            var taskToEdit = _db.Tasks.FirstOrDefault(task => task.IdTask == id);

            if (taskToEdit == null)
            {
                throw new ToDoListException("This Task doesnt exist");
            }

            return taskToEdit;
        }

       
    }
}
