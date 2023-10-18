using Volo.Abp.Reflection;

namespace LKN.AuthMicroService.Permissions;

public class AuthMicroServicePermissions
{
    public const string GroupName = "AuthMicroService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AuthMicroServicePermissions));
    }
}
