using LKN.Payment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.Payment;

public abstract class PaymentController : AbpControllerBase
{
    protected PaymentController()
    {
        LocalizationResource = typeof(PaymentResource);
    }
}
