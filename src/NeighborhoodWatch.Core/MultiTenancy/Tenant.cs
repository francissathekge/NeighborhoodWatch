using Abp.MultiTenancy;
using NeighborhoodWatch.Authorization.Users;

namespace NeighborhoodWatch.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
