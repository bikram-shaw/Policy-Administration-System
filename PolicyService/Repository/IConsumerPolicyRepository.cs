using PolicyService.Data.Entities;

namespace PolicyService.Repository
{
    public interface IConsumerPolicyRepository
    {
        bool CreateConsumerPolicy(ConsumerPolicy consumerPolicy);
        public PolicyMaster GetPolicy(string PId);
        public bool IssuePolicy(long PId, long CustId);
    }
}
