using ConsumerService.Data.Entities;

namespace ConsumerService.Repository
{
    public interface IConsumerBusinessRepository
    {
        public bool CreateConsumer(ConsumerDetails consumerDetails);
        public bool UpdateConsumer(ConsumerDetails consumerDetails);
        public ConsumerDetails GetConsumerDetails(long consumerId);

    }
}
