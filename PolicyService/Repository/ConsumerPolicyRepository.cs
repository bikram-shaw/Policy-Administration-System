using PolicyService.Data;
using PolicyService.Data.Entities;
using System.Linq;

namespace PolicyService.Repository
{
    public class ConsumerPolicyRepository : IConsumerPolicyRepository
    {
        private readonly PolicyServiceContext policyServiceContext;

        public ConsumerPolicyRepository(PolicyServiceContext context)
        {
            this.policyServiceContext = context;
        }

        public bool CreateConsumerPolicy(ConsumerPolicy consumerPolicy)
        {
           policyServiceContext.ConsumerPolicies.Add(consumerPolicy);
            return SaveChanges();
        }

        public PolicyMaster GetPolicy(string PId)
        {
            PolicyMaster policyMaster = policyServiceContext.PolicyMasters.Where(cp => cp.Id == PId).FirstOrDefault();
            return policyMaster;
        }

        public bool IssuePolicy(long PId,long CustId)
        {
            ConsumerPolicy consumerPolicy=policyServiceContext.ConsumerPolicies.Where(cp => cp.Id == PId & cp.ConsumerId == CustId).FirstOrDefault();
            if (consumerPolicy != null)
            {
                consumerPolicy.Status = "Approve";
                return SaveChanges();
            }
            return false;
        }

        private bool SaveChanges()
        {
            if (policyServiceContext.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
