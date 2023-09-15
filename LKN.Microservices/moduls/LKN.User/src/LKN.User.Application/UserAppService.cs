using LKN.User.Localization;
using Volo.Abp.Application.Services;

namespace LKN.User;

public abstract class UserAppService : ApplicationService
{
    protected UserAppService()
    {
        LocalizationResource = typeof(UserResource);
        ObjectMapperContext = typeof(UserApplicationModule);
    }
}
