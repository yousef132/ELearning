using AutoMapper;
using AutoMapper.Execution;
using E_Learning.Models;
using ELearning.Data.Entities.Question;
using Store.Repository.Interfaces;

namespace E_Learning.MappingProfiles.StudentAnswer
{
    public class StudentAnswerResolver : IValueResolver<CompleteExamViewModel, ELearning.Data.Entities.StudentAnswer, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentAnswerResolver(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool Resolve(CompleteExamViewModel source, ELearning.Data.Entities.StudentAnswer destination, bool destMember, ResolutionContext context)
        {
            var question = unitOfWork.Reposirory<BaseQuestion>().GetById(source.BaseQuestionId);  

            if(question.AnswerChoice == source.AnswerChoice)
                return true;

            return false;
        }
    }
}
