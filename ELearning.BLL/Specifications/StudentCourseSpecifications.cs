using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications
{
    public class StudentCourseSpecifications : BaseSpecification<StudentCourse>
    {
        public StudentCourseSpecifications(string userId) :
            base(sc => sc.UserId == userId)
        {
            AddInclude(sc => sc.Course);
        }
    }
}
