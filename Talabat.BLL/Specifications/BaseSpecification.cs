using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;
namespace Talabat.BLL.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteiria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDecending { get; set; }
        public int Take { get; set;  }
        public int Skip { get; set; }
        public bool ISPaginEnable { get; set;  }

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> Criteiria)
        {
            this.Criteiria = Criteiria;
        }
        public void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);

        }

        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;

        }

        public void AddOrderByDEsc(Expression<Func<T, object>> orderByDesc)
        {
            OrderByDecending = orderByDesc;

        }

        public void ApplyPagination(int skip , int take)
        {

            ISPaginEnable = true;
            Skip = skip;
            Take = take;
        }
    }
}
