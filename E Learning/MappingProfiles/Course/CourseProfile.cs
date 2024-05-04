using AutoMapper;
using E_Learning.Models;
using ELearning.Data.Entities;
namespace E_Learning.Mapper.Course
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<ELearning.Data.Entities.Course, CartCourse>().ReverseMap();
            CreateMap<ELearning.Data.Entities.Course, CourseViewModel>().ReverseMap();
        }
    }
}
