using LKN.Order.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.Order;

public abstract class OrderController : AbpControllerBase
{
    protected OrderController()
    {
        LocalizationResource = typeof(OrderResource);
    }
}
