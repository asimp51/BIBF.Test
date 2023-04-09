using System.Collections.Generic;
using BIBF.Test.Roles.Dto;

namespace BIBF.Test.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}