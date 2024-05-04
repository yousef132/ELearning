using ELearning.DAL.Context.Identity;
using ELearning.Data.Entities.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities
{
    public class StudentQuestion
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


        public BaseQuestion BaseQuestion { get; set; }
        public int BaseQuestionId { get; set; }

        // the answer
        //public Choice Choice { get; set; }
        public int StudentAnswerId { get; set; }   
    }
}
