using AutoMapper;
using E_Learning.Mapper.Instructor;
using E_Learning.Models;
using ELearning.Data.Entities;
namespace E_Learning.MappingProfiles.StudentAnswer
{
    public class StudentAnswerProfile:Profile
    {
        public StudentAnswerProfile()
        {
            CreateMap<CompleteExamViewModel, ELearning.Data.Entities.StudentAnswer>().
                ForMember(dest => dest.AnswerIsCorrect, option => option.MapFrom<StudentAnswerResolver>());
        }
    }
}
