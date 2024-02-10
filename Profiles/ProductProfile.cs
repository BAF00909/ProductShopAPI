using AutoMapper;

namespace ProductShop.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.ProductCreateDto, Entities.Product>();
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductDto, Entities.Product>();
        }
    }
}
