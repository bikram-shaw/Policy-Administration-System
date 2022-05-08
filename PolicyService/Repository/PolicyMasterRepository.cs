using PolicyService.Data;
using PolicyService.Data.Entities;
using PolicyService.Models;
using System.Linq;

namespace PolicyService.Repository
{
    public class PolicyMasterRepository : IPolicyMasterRepository
    {
        private readonly PolicyServiceContext context;

        public PolicyMasterRepository(PolicyServiceContext context)
        {
            this.context = context;
        }

        public PolicyMaster GetPolicyMaster(long businessValue, long propertyValue)
        {
            return context.PolicyMasters.Where(pm=>pm.BusinessValue==businessValue && pm.PropertyValue==propertyValue).FirstOrDefault();
        }
    }
}
