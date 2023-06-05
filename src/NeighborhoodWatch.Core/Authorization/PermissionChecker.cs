using Abp.Authorization;
using NeighborhoodWatch.Authorization.Roles;
using NeighborhoodWatch.Authorization.Users;

namespace NeighborhoodWatch.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
