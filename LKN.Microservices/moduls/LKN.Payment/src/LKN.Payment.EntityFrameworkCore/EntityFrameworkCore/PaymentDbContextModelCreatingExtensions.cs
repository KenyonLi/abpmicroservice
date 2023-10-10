using LKN.Payment.Pays;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.Payment.EntityFrameworkCore;

public static class PaymentDbContextModelCreatingExtensions
{
    public static void ConfigurePayment(
        this ModelBuilder builder,
        Action<PaymentModelBuilderConfigurationOptions> optionsAction = null )
    {
        Check.NotNull(builder, nameof(builder));

        var options = new PaymentModelBuilderConfigurationOptions(
            PaymentDbProperties.DbTablePrefix,
            PaymentDbProperties.DbSchema
        );
        
        optionsAction?.Invoke(options);

        // 1、引入支付实体（迁移表）
        builder.Entity<Payments>(b => {
            b.ConfigureByConvention();
        });
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(PaymentDbProperties.DbTablePrefix + "Questions", PaymentDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
