using System.Collections.Generic;
using System.Linq;
using BIBF.Test.Roles.Dto;
using BIBF.Test.Users.Dto;

namespace BIBF.Test.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
