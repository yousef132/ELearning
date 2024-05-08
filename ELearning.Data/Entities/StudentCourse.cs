using ELearning.DAL.Context.Identity;

namespace ELearning.Data.Entities
{
    public class StudentCourse : BaseEntity
    {

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

        public double TotalMark { get; set; }
    }
}
