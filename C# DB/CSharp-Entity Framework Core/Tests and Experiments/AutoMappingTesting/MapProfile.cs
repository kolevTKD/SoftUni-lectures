namespace AutoMappingTesting
{
    using AutoMapper;

    using DTOs;
    using Models;

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                       .ForMember(m => m.FullName, opt => opt
                            .MapFrom(e => $"{e.FirstName} {e.MiddleName} {e.LastName}"));
        }
    }
}
