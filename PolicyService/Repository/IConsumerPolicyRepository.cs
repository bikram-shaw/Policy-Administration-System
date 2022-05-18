using PolicyService.Data.Entities;

namespace PolicyService.Repository
{
    public interface IConsumerPolicyRepository
    {
        bool CreateConsumerPolicy(ConsumerPolicy consumerPolicy);
        public ConsumerPolicy GetPolicy(string PId);
        public bool IssuePolicy(string PId, long CustId);
    }
}
