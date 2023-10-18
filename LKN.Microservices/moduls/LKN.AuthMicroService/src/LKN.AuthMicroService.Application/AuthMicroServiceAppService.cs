using LKN.AuthMicroService.Localization;
using Volo.Abp.Application.Services;

namespace LKN.AuthMicroService;

public abstract class AuthMicroServiceAppService : ApplicationService
{
    protected AuthMicroServiceAppService()
    {
        LocalizationResource = typeof(AuthMicroServiceResource);
        ObjectMapperContext = typeof(AuthMicroServiceApplicationModule);
    }
}
