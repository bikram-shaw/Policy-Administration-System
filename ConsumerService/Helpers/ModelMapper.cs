using AutoMapper;
using ConsumerService.Data.Entities;
using ConsumerService.Models;

namespace ConsumerService.Helpers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<ConsumerDetails, ConsumerDetailsModel>();
            CreateMap<BusinessDetails, BusinessDetailsModel>();
            CreateMap<PropertyDetails, PropertyDetailsModel>();
           
        }
    }
}
