using AutoMapper;
using CubatelToDoListApp.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Business.Mappers
{
    public class TaskMapProfile : Profile
    {
        public TaskMapProfile()
        {
            CreateMap<TaskDto, DataService.Entities.Task>();
            CreateMap<DataService.Entities.Task, TaskDto>();
        }
    }
}
