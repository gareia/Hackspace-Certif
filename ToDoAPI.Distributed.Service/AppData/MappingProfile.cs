using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Application.DTO;
using ToDoAPI.Crosscuting.Extensions;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Distributed.Service.AppData
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDTO>()
                .ForMember(src => src.LimitDate, opt => opt.MapFrom(src => src.LimitDate.DtToString()))
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.DtToString()));
            CreateMap<ToDoItemCreationDTO, ToDoItem>()
                .ForMember(src => src.LimitDate, opt => opt.MapFrom(src => src.LimitDate.ToDateTime()));
            CreateMap<ToDoItemModificationDTO, ToDoItem>()
                .ForMember(src => src.LimitDate, opt => opt.MapFrom(src => src.LimitDate.ToDateTime()));
        }
    }
}
