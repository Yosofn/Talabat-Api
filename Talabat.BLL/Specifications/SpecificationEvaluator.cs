using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputquery,ISpecification<TEntity> specification)
        {
            var query=inputquery;
            if (specification.Criteiria != null)
                query = query.Where(specification.Criteiria);

            if (specification.OrderBy != null)
                query= query.OrderBy(specification.OrderBy);


            if (specification.OrderByDecending != null)
                query = query.OrderByDescending(specification.OrderByDecending);

            if (specification.ISPaginEnable)
                query=query.Skip(specification.Skip).Take(specification.Take);

            //context.set<Product>

            query = specification.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            return query;
            

        }
    }
}
