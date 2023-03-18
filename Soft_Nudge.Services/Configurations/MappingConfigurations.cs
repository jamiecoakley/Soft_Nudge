using AutoMapper;
using Soft_Nudge.Data.Entites;
using Soft_Nudge.Models.CategoryModels;
using Soft_Nudge.Models.NoteModels;
using Soft_Nudge.Models.ToDoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Services.Configurations
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations() 
        {
            CreateMap<ToDo, ToDoCreate>().ReverseMap();
            CreateMap<ToDo, ToDoDetail>().ReverseMap();
            CreateMap<ToDo, ToDoEdit>().ReverseMap();
            CreateMap<ToDo, ToDoListItem>().ReverseMap();

            CreateMap<Category, CategoryCreate>().ReverseMap();
            CreateMap<Category, CategoryDetail>().ReverseMap();
            CreateMap<Category, CategoryEdit>().ReverseMap();
            CreateMap<Category, CategoryListItem>().ReverseMap();

            CreateMap<Note, NoteCreate>().ReverseMap();
            CreateMap<Note, NoteDetail>().ReverseMap();
            CreateMap<Note, NoteEdit>().ReverseMap();
            CreateMap<Note, NoteListItem>().ReverseMap();
        }
    }
}
