using PolicyService.Data;
using PolicyService.Data.Entities;
using PolicyService.Models;
using System.Linq;

namespace PolicyService.Repository
{
    public class PolicyMasterRepository : IPolicyMasterRepository
    {
        private readonly PolicyServiceContext policyServiceContext;

        public PolicyMasterRepository(PolicyServiceContext context)
        {
            this.policyServiceContext = context;
        }

        public PolicyMaster GetPolicyMaster(long businessValue, long propertyValue)
        {
            return policyServiceContext.PolicyMasters.Where(pm=>pm.BusinessValue==businessValue && pm.PropertyValue==propertyValue).FirstOrDefault();
        }
    }
}
