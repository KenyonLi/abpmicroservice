﻿using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LKN.Payment.MongoDB;

public static class PaymentMongoDbContextExtensions
{
    public static void ConfigurePayment(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
