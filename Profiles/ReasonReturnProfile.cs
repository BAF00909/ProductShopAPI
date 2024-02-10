using AutoMapper;

namespace ProductShop.Profiles
{
    public class ReasonReturnProfile: Profile
    {
        public ReasonReturnProfile()
        {
            CreateMap<Models.ReasonReturCreateDto, Entities.ReasonReturn>();
            CreateMap<Entities.ReasonReturn, Models.ReasonReturnDto>();
            CreateMap<Models.ReasonReturnDto, Entities.ReasonReturn>();
        }
    }
}
