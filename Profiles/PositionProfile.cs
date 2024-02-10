using AutoMapper;

namespace ProductShop.Profiles
{
    public class PositionProfile: Profile
    {
        public PositionProfile()
        {
            CreateMap<Entities.Position, Models.PositionDto>();
            CreateMap<Models.PositionDto, Entities.Position>();
            CreateMap<Models.PositionCreateDto, Entities.Position>();
        }
    }
}
