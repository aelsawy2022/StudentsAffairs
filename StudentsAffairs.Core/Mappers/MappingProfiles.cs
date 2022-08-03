using AutoMapper;
using StudentsAffairs.Models;
using StudentsAffairs.Persistance.Data.Entities;
using System.Linq;

namespace StudentsAffairs.Core.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<User, UsersModel>()
            //    .ForMember(dto => dto.Roles, conf => conf.MapFrom(r => r.UserRoles.Select(ur => ur.Role).ToList()))
            //    .ReverseMap();

            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Class, ClassModel>().ReverseMap();
        }
    }
}
