using LKN.User.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.User;

public abstract class UserController : AbpControllerBase
{
    protected UserController()
    {
        LocalizationResource = typeof(UserResource);
    }
}
