using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Interface
{
    public interface IGenaricReposatory<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task <IReadOnlyList <T>> GetAllAsync();

        Task<T> GetByIdSpecAsync(ISpecification<T>specificaition);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specificaition);

        Task<int> GetCountAsync(ISpecification<T> specificaition);

    }
}
