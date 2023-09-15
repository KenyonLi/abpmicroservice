using Volo.Abp.Reflection;

namespace LKN.Product.Permissions;

public class ProductPermissions
{
    public const string GroupName = "Product";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductPermissions));
    }
}
