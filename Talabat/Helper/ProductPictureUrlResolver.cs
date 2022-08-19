using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.DAL.Entities;
using Talabat.DTO;

namespace Talabat.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDTo, string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, ProductDTo destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["ApiUrl"]}{source.PictureUrl}";

            return null;
        }
    }
}
