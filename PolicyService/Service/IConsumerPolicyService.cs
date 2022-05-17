using PolicyService.Data.Entities;
using PolicyService.Models;

namespace PolicyService.Service
{
    public interface IConsumerPolicyService
    {
        bool CreateConsumerPolicy(ConsumerPolicyModel consumerPolicyModel,string token);
        public PolicyMasterModel GetPolicy(string PId);
        public bool IssuePolicy(long PId, long CustId);
    }
}
