using AutoMapper;
using ShopSmithAPI.Dto;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Mappings
{
    public class LaborProfile : Profile
    {
        public LaborProfile() 
        {
            CreateMap<Labor, LaborDto>();
            CreateMap<LaborDto, Labor>();
        }
    }
}
