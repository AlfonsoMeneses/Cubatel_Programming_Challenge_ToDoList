using AutoMapper;
using CubatelToDoListApp.Contracts.Models;
using CubatelToDoListApp.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubatelToDoListApp.Business.Mappers
{
    public class ItemMapProfile : Profile
    {
        public ItemMapProfile()
        {
            CreateMap<TaskItemDto, Item>();
            CreateMap<Item, TaskItemDto>();
        }
    }
}
