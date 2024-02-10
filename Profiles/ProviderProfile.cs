using AutoMapper;

namespace ProductShop.Profiles
{
    public class ProviderProfile: Profile
    {
        public ProviderProfile()
        {
            CreateMap<Models.ProviderCreateDto, Entities.Provider>();
            CreateMap<Entities.Provider, Models.ProviderDto>();
        }
    }
}
