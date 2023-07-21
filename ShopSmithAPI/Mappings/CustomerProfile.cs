using AutoMapper;
using ShopSmithAPI.Dto;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
