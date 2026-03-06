using APIsNET.Domain.DTOs;
using APIsNET.Domain.Model.EmployeeAggregate;
using AutoMapper;

namespace APIsNET.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}
