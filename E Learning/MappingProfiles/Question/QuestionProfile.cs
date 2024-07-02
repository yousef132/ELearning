using AutoMapper;
using E_Learning.Models;
using ELearning.Data.Entities.Question;

namespace E_Learning.MappingProfiles.Question
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionViewModel,BaseQuestion>().ReverseMap();   
        }
    }
}
