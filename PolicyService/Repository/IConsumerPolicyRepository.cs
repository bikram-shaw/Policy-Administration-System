using PolicyService.Data.Entities;

namespace PolicyService.Repository
{
    public interface IConsumerPolicyRepository
    {
        bool CreateConsumerPolicy(ConsumerPolicy consumerPolicy);
    }
}
