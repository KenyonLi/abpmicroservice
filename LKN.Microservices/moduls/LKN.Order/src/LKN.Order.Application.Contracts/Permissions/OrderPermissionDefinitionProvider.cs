using LKN.Order.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LKN.Order.Permissions;

public class OrderPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(OrderPermissions.GroupName, L("Permission:Order"));
        var myGroup = context.AddGroup(OrderPermissions.GroupName);

        var permissionDefinition = myGroup.AddPermission(OrderPermissions.Orders.Default);
        permissionDefinition.AddChild(OrderPermissions.Orders.Update);
        permissionDefinition.AddChild(OrderPermissions.Orders.Create);
        permissionDefinition.AddChild(OrderPermissions.Orders.Delete);
        permissionDefinition.AddChild(OrderPermissions.Orders.Select);

        permissionDefinition.AddChild("select");
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OrderResource>(name);
    }
}
