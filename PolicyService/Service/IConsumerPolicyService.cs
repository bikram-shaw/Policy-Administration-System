using PolicyService.Models;

namespace PolicyService.Service
{
    public interface IConsumerPolicyService
    {
        bool CreateConsumerPolicy(ConsumerPolicyModel consumerPolicyModel);
    }
}
