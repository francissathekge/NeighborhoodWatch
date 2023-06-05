using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using NeighborhoodWatch.Authorization.Roles;
using Abp.Domain.Uow;

namespace NeighborhoodWatch.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor,
                  unitOfWorkManager)
        {
        }
    }
}
