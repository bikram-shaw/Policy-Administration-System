using PolicyService.Data;
using PolicyService.Data.Entities;

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

        private bool SaveChanges()
        {
            if (context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
