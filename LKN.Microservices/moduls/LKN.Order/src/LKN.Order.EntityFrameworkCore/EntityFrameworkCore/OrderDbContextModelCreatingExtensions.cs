using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.Order.EntityFrameworkCore;

public static class OrderDbContextModelCreatingExtensions
{
    public static void ConfigureOrder(
        this ModelBuilder builder,
        Action<OrderModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(OrderDbProperties.DbTablePrefix + "Questions", OrderDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        // 表名的前缀配置
        var options = new OrderModelBuilderConfigurationOptions(
            OrderDbProperties.DbTablePrefix,
            OrderDbProperties.DbSchema
        );
        optionsAction?.Invoke(options);

        builder.Entity<LKN.Order.Orders.Order>(b =>
        {
            b.ConfigureByConvention();
            b.HasMany(u => u.OrderItems).WithOne().HasForeignKey(ur => ur.OrderId).IsRequired();
        });

    }
}
