using Volo.Abp.Modularity;

namespace LKN.Payment;

[DependsOn(
    typeof(PaymentApplicationModule),
    typeof(PaymentDomainTestModule)
    )]
public class PaymentApplicationTestModule : AbpModule
{

}
