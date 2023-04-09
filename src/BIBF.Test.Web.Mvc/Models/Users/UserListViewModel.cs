using System.Collections.Generic;
using BIBF.Test.Roles.Dto;

namespace BIBF.Test.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
