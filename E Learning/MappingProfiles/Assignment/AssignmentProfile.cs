using AutoMapper;
using E_Learning.Models;

namespace E_Learning.MappingProfiles.Assignment
{
    public class AssignmentProfile:Profile  
    {
        public AssignmentProfile()
        {
            CreateMap<AssignmentViewModel, ELearning.Data.Entities.Assignment>().ReverseMap();   
        }

    }
}
