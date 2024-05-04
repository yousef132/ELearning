using ELearning.DAL.Context.Identity;

namespace ELearning.Data.Entities
{
    public class StudentExam
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        public double Grade { get; set; }


        public Exam Exam { get; set; }
        public int ExamId { get; set; }


    }
}
