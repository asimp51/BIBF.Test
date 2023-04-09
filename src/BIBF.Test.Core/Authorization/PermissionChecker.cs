using Abp.Authorization;
using BIBF.Test.Authorization.Roles;
using BIBF.Test.Authorization.Users;

namespace BIBF.Test.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
