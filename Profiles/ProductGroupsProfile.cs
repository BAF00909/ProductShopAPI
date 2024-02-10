using AutoMapper;

namespace ProductShop.Profiles
{
    public class ProductGroupsProfile: Profile
    {
        public ProductGroupsProfile()
        {
            CreateMap<Models.ProductGroupCreateDto, Entities.ProductGroup>();
            CreateMap<Entities.ProductGroup, Models.ProductGroupDto>();
            CreateMap<Models.ProductGroupDto, Entities.ProductGroup>();
        }
    }
}
