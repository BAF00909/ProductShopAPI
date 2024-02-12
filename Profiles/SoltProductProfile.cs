using AutoMapper;

namespace ProductShop.Profiles
{
    public class SoltProductProfile: Profile
    {
        public SoltProductProfile()
        {
            CreateMap<Models.SoltProductCreateDto, Entities.SoltProduct>();
            CreateMap<Entities.SoltProduct, Models.SoltProductDto>();
            CreateMap<Models.SoltProductUpdateDto, Entities.SoltProduct>();
        }
    }
}
