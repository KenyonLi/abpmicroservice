using LKN.AuthMicroService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LKN.AuthMicroService.Permissions;

public class AuthMicroServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AuthMicroServicePermissions.GroupName, L("Permission:AuthMicroService"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AuthMicroServiceResource>(name);
    }
}
