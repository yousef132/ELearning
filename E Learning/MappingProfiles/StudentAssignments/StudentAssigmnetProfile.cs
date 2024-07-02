using AutoMapper;
using E_Learning.Models;
using ELearning.Data.Entities;

namespace E_Learning.MappingProfiles.StudentAssignments
{
    public class StudentAssigmnetProfile : Profile
    {
        public StudentAssigmnetProfile()
        {
            CreateMap<StudentAssignment, EvaluateAssignmentViewModel>();
        }
    }
}
