using ELearning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications.ExamSpecificatoin
{
    public class ExamWithSpecifications : BaseSpecification<Exam>
    {
        public ExamWithSpecifications(ExamSpecifications specs)
            : base(e => (e.Id == specs.ExamId || specs.ExamId == null)&&
                  (e.CourseId == specs.CourseId || specs.CourseId == null) )
        {
            AddInclude(e => e.BaseQuestions);
        }


        
    }
}
