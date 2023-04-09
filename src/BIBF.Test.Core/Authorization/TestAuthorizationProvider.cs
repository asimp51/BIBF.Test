using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BIBF.Test.Authorization
{
    public class TestAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
         
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var products = pages.CreateChildPermission(PermissionNames.Pages_Products, L("Products"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Create, L("CreateNewProduct"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Edit, L("EditProduct"));
            products.CreateChildPermission(PermissionNames.Pages_Products_Delete, L("DeleteProduct"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TestConsts.LocalizationSourceName);
        }
    }
}
