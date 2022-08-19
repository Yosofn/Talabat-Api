using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class ProductWithFilterCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterCountSpecification(ProductSpecParam productSpecParam) : base(p =>

         (string.IsNullOrEmpty(productSpecParam.Search) || p.Name.ToLower().Contains(productSpecParam.Search)
            ) &&
              (!productSpecParam.typeid.HasValue || p.ProductTypeId == productSpecParam.typeid.Value)

              &&
               (!productSpecParam.brandid.HasValue || p.ProductBrandId == productSpecParam.brandid.Value)

            )
        { 

          }
} 
    
}
