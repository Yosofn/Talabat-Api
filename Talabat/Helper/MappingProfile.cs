using AutoMapper;
using Talabat.DAL.Entities;
using Talabat.DTO;

namespace Talabat.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductDTo>()
            .ForMember(d => d.types, o => o.MapFrom(S => S.Producttypes.Name))
            .ForMember(d => d.brands, o => o.MapFrom(S => S.ProductBrands.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>()
            );
        }
    }
}
