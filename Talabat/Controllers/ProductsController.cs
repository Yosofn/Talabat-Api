using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.BLL.Interface;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;
using Talabat.DTO;
using Talabat.Helper;

namespace Talabat.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenaricReposatory<Product> productsReposatory;
        private readonly IGenaricReposatory<ProductBrand> brandsrepo;
        private readonly IGenaricReposatory<ProductType> typerepo;
        private readonly IMapper mapper;

        public ProductsController(IGenaricReposatory<Product> productsReposatory,IGenaricReposatory<ProductBrand> brandsrepo,IGenaricReposatory<ProductType> typerepo, IMapper mapper)
        {
            this.productsReposatory = productsReposatory;
            this.brandsrepo = brandsrepo;
            this.typerepo = typerepo;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<Pagination<ProductDTo>>> GetProducts( ProductSpecParam productSpecParam)
        {
            var specification = new ProductWithTypeAndBrandSpecification(productSpecParam);

            var products = await productsReposatory.GetAllWithSpecAsync(specification);
            var Data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTo>>(products);
            var countspec = new ProductWithFilterCountSpecification(productSpecParam);
            var count =await productsReposatory.GetCountAsync(specification);

            if (Data == null)
                return NotFound();

            return Ok(new Pagination< ProductDTo >(productSpecParam.PageIndex,productSpecParam.PageSize,count,Data));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]

        public async Task<ActionResult<ProductDTo>> GetProduct(int id)
        {
            var specification = new ProductWithTypeAndBrandSpecification( id);

            var products = await productsReposatory.GetByIdSpecAsync(specification);

            return Ok(mapper.Map<Product,ProductDTo>(products));
        }


        [HttpGet("brands")]

        public async Task <ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands =await brandsrepo.GetAllAsync();

            return Ok(brands);


        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await typerepo.GetAllAsync();

            return Ok(types);


        }
    }
}
