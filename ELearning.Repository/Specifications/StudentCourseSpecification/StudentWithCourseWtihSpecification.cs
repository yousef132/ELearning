using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications.StudentCourseSpecification
{
    public class StudentWithCourseWtihSpecification : BaseSpecification<StudentCourse>
    {
        public StudentWithCourseWtihSpecification(StudentCourseSpecification specs)
            : base(sc => (sc.CourseId == specs.CourseId))
        {
            AddOrderByDescending(sc => sc.TotalMark);
            AddInclude(sc => sc.User);
        }
    }
}
