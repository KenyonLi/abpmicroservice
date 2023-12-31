﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LKN.Order.MongoDB;

[ConnectionStringName(OrderDbProperties.ConnectionStringName)]
public interface IOrderMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
