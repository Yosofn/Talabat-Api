using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        //This constructor is used to get all products
        public ProductWithTypeAndBrandSpecification(ProductSpecParam productSpecParam)
            : base(p =>
             (string.IsNullOrEmpty(productSpecParam.Search) || p.Name.ToLower().Contains(productSpecParam.Search)
            )&&
            ( !productSpecParam.typeid.HasValue|| p.ProductTypeId == productSpecParam.typeid.Value)
            
            &&
             (!productSpecParam.brandid.HasValue || p.ProductBrandId == productSpecParam.brandid.Value)
            
            )
        {
            AddInclude(p => p.Producttypes);
            AddInclude(p => p.ProductBrands);
            AddOrderBy(p => p.Name);
            // index =2 page size =5
            ApplyPagination(productSpecParam.PageSize * (productSpecParam.PageIndex - 1), productSpecParam.PageSize);


            if (! string.IsNullOrEmpty(productSpecParam.sort))
            {

                switch (productSpecParam.sort)
                {
                    case "priceAsc":
                        AddOrderBy(P =>P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDEsc(P =>P.Price);
                        break;

                    default:
                        AddOrderBy(p=>p.Name);
                        break;
                }

            }
        }
        public ProductWithTypeAndBrandSpecification(int id):base(P=>P.Id==id)
        {
            AddInclude(p => p.Producttypes);
            AddInclude(p => p.ProductBrands);
        }

    }
}
