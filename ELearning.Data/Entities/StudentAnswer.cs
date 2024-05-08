using ELearning.DAL.Context.Identity;
using ELearning.Data.Entities.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities
{
    public class StudentAnswer:BaseEntity
    {

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public BaseQuestion BaseQuestion { get; set; }
        public int BaseQuestionId { get; set; }
        // Assignmet With Value Via Mapping Resolver function 
        public bool AnswerIsCorrect { get; set; }   
    }
}
