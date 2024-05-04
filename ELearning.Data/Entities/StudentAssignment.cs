using ELearning.DAL.Context.Identity;

namespace ELearning.Data.Entities
{
    public class StudentAssignment
    {
        // Student Submit Many Assignments & Assignment Submitted By Many Students
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public double Mark {  get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
    }
}
