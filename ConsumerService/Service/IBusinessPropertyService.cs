using ConsumerService.Models;
using System.Collections.Generic;

namespace ConsumerService.Service
{
    public interface IBusinessPropertyService
    {
        public bool CreateBusinessProperty(PropertyDetailsModel propertyDetailsModel);
        public bool UpdateBusinessProperty(long propertyId,PropertyDetailsModel propertyDetailsModel);
        public List<PropertyDetailsModel> GetBusinessProperty(long businessId);
    }
}
