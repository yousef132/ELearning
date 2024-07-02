using ELearning.DAL.Context.Identity;

namespace ELearning.Data.Entities
{
    public class StudentCourse : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

        // Maintain a running total of student's marks after each exam/assignment.
        // Update the total marks each time an exam or assignment is graded instead of 
        // calculating the total on-the-fly from assignments and studentexam tables.
        // This saves computation time during queries by using precomputed and stored total marks.
        public double TotalMark { get; set; }
    }
}
