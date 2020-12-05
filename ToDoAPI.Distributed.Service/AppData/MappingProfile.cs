using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Distributed.Service.AppData
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDTO>();
            CreateMap<ToDoItemCreationDTO, ToDoItem>();
            CreateMap<ToDoItem, ToDoItemModificationDTO>();
            CreateMap<ToDoItemModificationDTO, ToDoItemDTO>();
        }
    }
}
