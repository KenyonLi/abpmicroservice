﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LKN.Order.MongoDB;

[ConnectionStringName(OrderDbProperties.ConnectionStringName)]
public class OrderMongoDbContext : AbpMongoDbContext, IOrderMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureOrder();
    }
}
