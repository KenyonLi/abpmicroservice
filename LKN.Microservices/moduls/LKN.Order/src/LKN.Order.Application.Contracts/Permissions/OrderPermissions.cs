using Volo.Abp.Reflection;

namespace LKN.Order.Permissions;

public class OrderPermissions
{
    public const string GroupName = "OrderService";

    public static class Orders
    {
        public const string Default = GroupName + ".Order";
        public const string Select = Default + ".Select";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string ManagePermissions = Default + ".ManagePermissions";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(OrderPermissions));
    }
}
