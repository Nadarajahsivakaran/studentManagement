using AutoMapper;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
using System.Diagnostics.Metrics;

namespace StudentManagement.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClassRoom, ClassRoomCreate>().ReverseMap();
            CreateMap<Student, StudentCreate>().ReverseMap();
            CreateMap<Student, StudentUpdate>().ReverseMap();
            CreateMap<Teacher, TeacherCreate>().ReverseMap();
            CreateMap<Subject, SubjectCreate>().ReverseMap();

        }
    }
}
