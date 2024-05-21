using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities.Question
{
    public class BaseQuestion : BaseEntity
    {
        public string Text { get; set; }

        //I didn't create a table for choices to avoid excessive includes 
        //For instance, when retrieving an exam, it's necessary to include the questions then include it's choices.
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }

        // 1 for choice 1 , 2 for choice 2 and so on 
        public int AnswerChoice { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }
    }
}
