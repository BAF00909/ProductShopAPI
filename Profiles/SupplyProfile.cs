using AutoMapper;

namespace ProductShop.Profiles
{
    public class SupplyProfile: Profile
    {
        public SupplyProfile()
        {
            CreateMap<Entities.Supply, Models.SupplyDto>();
            CreateMap<Models.SupplyCreateDto, Entities.Supply>();
        }
    }
}
