using AutoMapper;
using E_Learning.Models;
using ELearning.DAL.Context.Identity;

namespace E_Learning.Mapper.Instructor
{
    public class InstructorUserNameResolver : IValueResolver<UpdateInstructorViewModel, ApplicationUser, string>
    {
        public string Resolve(UpdateInstructorViewModel source, ApplicationUser destination, string destMember, ResolutionContext context)
                => source.Email.Split('@')[0];
    }
}
