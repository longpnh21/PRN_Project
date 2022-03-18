using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using UniClub.Specifications.Interfaces;

namespace UniClub.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> specifications)
        {
            // Do not apply anything if specifications is null
            if (specifications == null)
            {
                return query;
            }

            // Modify the IQueryable
            // Apply filter conditions
            foreach (var condition in specifications.FilterCondition)
            {
                query = query.Where(condition);
            }

            // Includes
            query = specifications.Includes
                        .Aggregate(query, (current, include) => current.Include(include));

            foreach (var navigationPath in specifications.StringIncludes)
            {
                query = query.Include(navigationPath);
            }


            // Apply ordering
            if (!string.IsNullOrEmpty(specifications.OrderBy))
            {
                query = specifications.IsAscending ? query.OrderBy($"{specifications.OrderBy}") : query.OrderBy($"{specifications.OrderBy} descending");
            }

            // Apply GroupBy
            if (specifications.GroupBy != null)
            {
                query = query.GroupBy(specifications.GroupBy).SelectMany(x => x);
            }

            return query;
        }
    }
}
