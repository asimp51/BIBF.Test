using System.Collections.Generic;
using BIBF.Test.Roles.Dto;

namespace BIBF.Test.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
