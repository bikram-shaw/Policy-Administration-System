using ConsumerService.Data.Entities;
using System.Collections.Generic;

namespace ConsumerService.Repository
{
    public interface IBusinessPropertyRepository
    {
        public bool CreateBusinessProperty(PropertyDetails propertyDetails);
        public bool UpdateBusinessProperty(PropertyDetails propertyDetails);
        public List<PropertyDetails> GetBusinessProperties(long businessId);
        public PropertyDetails GetBusinessProperty(long propertyId);
    }
}
