using PolicyService.Data.Entities;
using PolicyService.Models;

namespace PolicyService.Repository
{
    public interface IPolicyMasterRepository
    {
        PolicyMaster GetPolicyMaster(long businessValue,long propertyValue);
    }
}
