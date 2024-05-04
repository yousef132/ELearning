using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications.CourseSpecification
{
    public class CourseWithSpecifications : BaseSpecification<Course>
    {
        public CourseWithSpecifications(CourseSpecifications specs)
            : base(course => (
            String.IsNullOrEmpty(specs.Name) || course.Name.Trim().ToLower().Contains(specs.Name.Trim().ToLower())) &&
            (specs.CourseId == course.Id || specs.CourseId == null) &&
            (course.UserId == specs.UserId || String.IsNullOrEmpty(specs.UserId)) &&
            ((course.Price >= specs.MinPrice && course.Price <= specs.MaxPrice) || (specs.MaxPrice == 0 && specs.MinPrice == 0)) &&
            ((specs.Levels.Contains(course.SkillLevel)) || (specs.Levels.Count == 0)) &&
            ((specs.Languages.Contains(course.Language)) || (specs.Languages.Count == 0))
            )
        {
            // include instructor
            AddInclude(course => course.User);
          //  ApplyPgination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
        }

        public CourseWithSpecifications(int courseId)
            : base(c => c.Id == courseId)
        {
            AddInclude(course => course.Lectures);
        }
    }
}
