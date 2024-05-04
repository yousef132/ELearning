using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Data.Entities.Question
{
    public class BaseQuestion:BaseEntity
    {
        public string Name { get; set; }

        // Id + ExamId => PK
        public Answer RightAnswer { get; set; }
        // own choices
        public ICollection<Choice> Choices { get; set; }
        public ICollection<StudentQuestion> StudentQuestions { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }
    }

}
