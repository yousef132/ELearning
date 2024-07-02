using ELearning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELearning.BLL.Specifications
{
    public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        // function to Generate Query

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,// base query
                                                    ISpecification<TEntity> specs)// Exstra specification
        {
            //q1
            var query = inputQuery;

            //q1 + where
            if (specs?.Criteria is not null)
                query = query.Where(specs.Criteria);

            if (specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDescending is not null)
                query = query.OrderByDescending(specs.OrderByDescending);

            if(specs.IsPaginated)
                query = query.Skip(specs.Skip).Take(specs.Take);


            // for Includes List
            // q1 + where + .include().include().include()...   <-include list
            query = specs.Includes.Aggregate(query
            //product           include()      => context.products.include() 
            , (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            return query;

        }
    }
}
