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

        public ConsumerPolicy GetPolicy(string PId)
        {
            ConsumerPolicy consumerPolicy = policyServiceContext.ConsumerPolicies.Where(cp => cp.ConsumerId == long.Parse(PId)).FirstOrDefault();
            return consumerPolicy;
        }

        public bool IssuePolicy(string PId,long CustId)
        {
            ConsumerPolicy consumerPolicy=policyServiceContext.ConsumerPolicies.Where(cp => cp.Pid == PId & cp.ConsumerId == CustId).FirstOrDefault();
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
