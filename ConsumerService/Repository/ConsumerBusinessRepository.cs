using ConsumerService.Data;
using ConsumerService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsumerService.Repository
{
    public class ConsumerBusinessRepository : IConsumerBusinessRepository
    {
        private readonly ConsumerBusinessContext context;

        public ConsumerBusinessRepository(ConsumerBusinessContext context)
        {
            this.context = context;
        }

        public bool CreateConsumer(ConsumerDetails consumerDetails)
        {
            context.ConsumerDetails.Add(consumerDetails);
            return SaveChanges();
        }

        public ConsumerDetails GetConsumerDetails(long consumerId)
        {
            return context.ConsumerDetails.Include(c => c.BusinessDetails).FirstOrDefault(c => c.Id == consumerId);
        }

        public bool UpdateConsumer(ConsumerDetails consumerDetails)
        {
            return SaveChanges();
        }

        private bool SaveChanges()
        {
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
