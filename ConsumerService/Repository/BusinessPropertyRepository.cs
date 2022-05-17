using ConsumerService.Data;
using ConsumerService.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ConsumerService.Repository
{
    public class BusinessPropertyRepository : IBusinessPropertyRepository
    {
        private readonly ConsumerBusinessContext consumerBusinessContext;

        public BusinessPropertyRepository(ConsumerBusinessContext consumerBusinessContext)
        {
           
            this.consumerBusinessContext = consumerBusinessContext;
        }

        public bool CreateBusinessProperty(PropertyDetails propertyDetails)
        {
            consumerBusinessContext.PropertyDetails.Add(propertyDetails);
           
            return SaveChanges();
        }

        public List<PropertyDetails> GetBusinessProperties(long businessId)
        {
            return consumerBusinessContext.PropertyDetails.Where(p=>p.BusinessId==businessId).ToList();
        }

        public PropertyDetails GetBusinessProperty(long propertyId)
        {
            return consumerBusinessContext.PropertyDetails.Where(p => p.Id == propertyId).FirstOrDefault();
        }

        public bool UpdateBusinessProperty(PropertyDetails propertyDetails)
        {
            
                return SaveChanges();
        }

        private bool SaveChanges()
        {
            if (consumerBusinessContext.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
