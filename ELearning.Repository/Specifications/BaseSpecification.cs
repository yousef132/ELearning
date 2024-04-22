using System.Linq.Expressions;

namespace ELearning.BLL.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> include)
            => Includes.Add(include);


        protected void AddOrderBy(Expression<Func<T, object>> orderBy)
            => this.OrderBy = orderBy;
        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescending)
            => this.OrderByDescending = OrderByDescending;
    }
}
