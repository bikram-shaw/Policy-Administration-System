using PolicyService.Data.Entities;
using PolicyService.Models;

namespace PolicyService.Service
{
    public interface IConsumerPolicyService
    {
        bool CreateConsumerPolicy(CreatePolicyModel createPolicyModel, string token);
        public ConsumerPolicyModel GetPolicy(string PId);
        public bool IssuePolicy(string PId, long CustId);
    }
}
