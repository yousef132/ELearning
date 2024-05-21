using ELearning.Data.Entities;

namespace E_Learning.Models
{
    public class AssignmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CourseId { get; set; }
        public TimedEntity TimedEntity { get; set; }
    }
}