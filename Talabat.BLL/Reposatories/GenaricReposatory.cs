using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Interface;
using Talabat.BLL.Specifications;
using Talabat.DAL.Data;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Reposatories
{
    public class GenaricReposatory<T> : IGenaricReposatory<T> where T : BaseEntity
    {
        public StoreContext context { get; }

        public GenaricReposatory(StoreContext context)
        {
            this.context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //context.set<product>().Include(p=>p.peoductbrand).Include(p=>p.productType).ToListAsync();
            return await context.Set<T>().ToListAsync();

        }


        public async Task<T> GetByIdAsync(int id)
        => await context.Set<T>().FindAsync(id);
        private IQueryable<T> ApplySpecification(ISpecification<T> ispecification)
        {

            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), ispecification);
        }

        public async Task<T> GetByIdSpecAsync(ISpecification<T> specificaition)
        {
            return await ApplySpecification(specificaition).FirstOrDefaultAsync();

        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specificaition)
        {
            return await ApplySpecification(specificaition).ToListAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<T> specificaition)
        => await ApplySpecification(specificaition).CountAsync();
    }
   
}
