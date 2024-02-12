using AutoMapper;

namespace ProductShop.Profiles
{
    public class ReturnedProductProfile: Profile
    {
        public ReturnedProductProfile()
        {
            CreateMap<Models.ReturnedProductCreateDto, Entities.ReturnedProduct>();
            CreateMap<Entities.ReturnedProduct, Models.ReturnedProductDto>();
            CreateMap<Models.ReturnedProductUpdateDto, Entities.ReturnedProduct>();
        }
    }
}
