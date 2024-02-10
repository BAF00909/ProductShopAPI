using AutoMapper;

namespace ProductShop.Profiles
{
    public class OverdueProductProfile: Profile
    {
        public OverdueProductProfile()
        {
            CreateMap<Models.OverdueProductCreateDto, Entities.OverdueProduct>();
            CreateMap<Entities.OverdueProduct, Models.OverdueProductDto>();
            CreateMap<Models.OverdueProductUpdateDto, Entities.OverdueProduct>();
            CreateMap<Models.OverdueProductUpdateDto, Models.OverdueProductDto>();
        }
    }
}
