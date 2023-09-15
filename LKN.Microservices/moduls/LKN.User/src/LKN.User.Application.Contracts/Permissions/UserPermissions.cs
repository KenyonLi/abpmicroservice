using Volo.Abp.Reflection;

namespace LKN.User.Permissions;

public class UserPermissions
{
    public const string GroupName = "User";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(UserPermissions));
    }
}
