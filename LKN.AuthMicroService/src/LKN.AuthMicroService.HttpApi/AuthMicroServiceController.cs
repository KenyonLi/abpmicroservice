using LKN.AuthMicroService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.AuthMicroService;

public abstract class AuthMicroServiceController : AbpControllerBase
{
    protected AuthMicroServiceController()
    {
        LocalizationResource = typeof(AuthMicroServiceResource);
    }
}
