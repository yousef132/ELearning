using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.BLL.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; } // where
        List<Expression<Func<T, object>>> Includes { get; }//Include

        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPaginated { get; }
    }
}
