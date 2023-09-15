using Volo.Abp.Reflection;

namespace LKN.Payment.Permissions;

public class PaymentPermissions
{
    public const string GroupName = "Payment";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PaymentPermissions));
    }
}
