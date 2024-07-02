using AutoMapper;
using E_Learning.Models;
using ELearning.Data.Entities;

namespace E_Learning.MappingProfiles.Assignment
{
    public class AssignmentProfile:Profile  
    {
        public AssignmentProfile()
        {
            CreateMap<AssignmentViewModel, ELearning.Data.Entities.Assignment>().ReverseMap();   
            CreateMap<StudentAssignmentViewModel, StudentAssignment>().ReverseMap();   
        }

    }
}
