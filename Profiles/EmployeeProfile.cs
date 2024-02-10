using AutoMapper;

namespace ProductShop.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, Models.EmployeeDto>();
            CreateMap<Models.EmployeeDto, Entities.Employee>();
            CreateMap<Models.EmployeeCreateDto, Entities.Employee>();
            CreateMap<Models.EmployeeUpdateDto, Entities.Employee>();
            CreateMap<Entities.Employee, Models.EmployeeUpdateDto>();
        }
    }
}
