using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Interfaces
{
    public interface IStudentCourseRepository
    {
        IReadOnlyList<StudentCourse> GetAllCourses(string userId);
        bool HasCourse(string userId, int courseId);
    }
}
