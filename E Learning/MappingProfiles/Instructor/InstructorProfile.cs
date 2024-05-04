using AutoMapper;
using E_Learning.Models;
using ELearning.DAL.Context.Identity;

namespace E_Learning.Mapper.Instructor
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<UpdateInstructorViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, options => options.MapFrom<InstructorUserNameResolver>())
                .ReverseMap();
        }
    }
}
