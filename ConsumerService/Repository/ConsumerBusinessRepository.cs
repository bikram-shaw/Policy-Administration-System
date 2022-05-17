using ConsumerService.Data;
using ConsumerService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsumerService.Repository
{
    public class ConsumerBusinessRepository : IConsumerBusinessRepository
    {
        private readonly ConsumerBusinessContext consumerBusinessContext;

        public ConsumerBusinessRepository(ConsumerBusinessContext context)
        {
            this.consumerBusinessContext = context;
        }

        public bool CreateConsumer(ConsumerDetails consumerDetails)
        {
            consumerBusinessContext.ConsumerDetails.Add(consumerDetails);
            return SaveChanges();
        }

        public ConsumerDetails GetConsumerDetails(long consumerId)
        {
            return consumerBusinessContext.ConsumerDetails.Include(c => c.BusinessDetails.Properties).FirstOrDefault(c => c.Id == consumerId);
        }

        public bool UpdateConsumer(ConsumerDetails consumerDetails)
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
