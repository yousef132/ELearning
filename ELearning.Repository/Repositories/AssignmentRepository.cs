using ELearning.Data.Context;
using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Store.Repository.Interfaces;

namespace ELearning.BLL.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ELearningDbContext context;

        public AssignmentRepository(ELearningDbContext context)
        {
            this.context = context;
        }
        public ICollection<Assignment> GetAssignmentsByCourseId(int courseId)
            => context.Assignments.Where(a => a.CourseId == courseId).ToList();

        public StudentAssignment GetStudentAssignment(string userId, int assigmentId)
            => context.StudentAssignments.Where(sa => sa.UserId == userId && assigmentId == sa.AssignmentId).FirstOrDefault();

        // Get Solved Assignments Ids For Specific User 
        public ICollection<int> GetStudentAssignments(string UserId)
        => context.StudentAssignments.Where(sa => sa.UserId == UserId).Select(sa => sa.AssignmentId).ToList();

        public ICollection<StudentAssignment> GetStudentsSubmissionsForAssignment(int assignmentId)
          => context.StudentAssignments.Include(sa => sa.User).Where(sa => sa.AssignmentId == assignmentId).ToList();

    }


}
