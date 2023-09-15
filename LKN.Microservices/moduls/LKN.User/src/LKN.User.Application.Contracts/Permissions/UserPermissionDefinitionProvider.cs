using LKN.User.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LKN.User.Permissions;

public class UserPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UserPermissions.GroupName, L("Permission:User"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UserResource>(name);
    }
}
