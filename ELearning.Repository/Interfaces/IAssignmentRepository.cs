using ELearning.Data.Entities;

namespace Store.Repository.Interfaces
{
    public interface IAssignmentRepository
    {
        ICollection<Assignment> GetAssignmentsByCourseId(int courseId);
        ICollection<int> GetStudentAssignments(string UserId);

        StudentAssignment GetStudentAssignment(string userId, int assigmentId);

        ICollection<StudentAssignment> GetStudentsSubmissionsForAssignment(int assignmentId);
    }

}
