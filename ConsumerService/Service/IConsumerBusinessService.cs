using ConsumerService.Models;

namespace ConsumerService.Service
{
    public interface IConsumerBusinessService
    {
        public bool CreateConsumer(ConsumerDetailsModel consumerDetailsModel);
        public bool UpdateConsumer(long consumerId,ConsumerDetailsModel consumerDetailsModel);
        public ConsumerDetailsModel GetConsumerDetails(long consumerId);
        public long CalculateBusinessValue(long businessTurnOver, long capitalInvested);
    }
}
