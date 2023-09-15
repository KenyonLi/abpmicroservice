using LKN.Order.Localization;
using Volo.Abp.Application.Services;

namespace LKN.Order;

public abstract class OrderAppService : ApplicationService
{
    protected OrderAppService()
    {
        LocalizationResource = typeof(OrderResource);
        ObjectMapperContext = typeof(OrderApplicationModule);
    }
}
