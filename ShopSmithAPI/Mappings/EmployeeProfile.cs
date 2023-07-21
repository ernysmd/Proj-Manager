using AutoMapper;
using ShopSmithAPI.Dto;
using ShopSmithAPI.Models;
using System.Runtime.InteropServices;

namespace ShopSmithAPI.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }

    }
}
