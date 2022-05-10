using PolicyService.Data;
using PolicyService.Data.Entities;
using System.Linq;

namespace PolicyService.Repository
{
    public class ConsumerPolicyRepository : IConsumerPolicyRepository
    {
        private readonly PolicyServiceContext context;

        public ConsumerPolicyRepository(PolicyServiceContext context)
        {
            this.context = context;
        }

        public bool CreateConsumerPolicy(ConsumerPolicy consumerPolicy)
        {
           context.ConsumerPolicies.Add(consumerPolicy);
            return SaveChanges();
        }

        public PolicyMaster GetPolicy(string PId)
        {
            PolicyMaster policyMaster = context.PolicyMasters.Where(cp => cp.Id == PId).FirstOrDefault();
            return policyMaster;
        }

        public bool IssuePolicy(long PId,long CustId)
        {
            ConsumerPolicy consumerPolicy=context.ConsumerPolicies.Where(cp => cp.Id == PId & cp.ConsumerId == CustId).FirstOrDefault();
            if (consumerPolicy != null)
            {
                consumerPolicy.Status = "Approve";
                return SaveChanges();
            }
            return false;
        }

        private bool SaveChanges()
        {
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
