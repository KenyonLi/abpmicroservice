﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LKN.AuthMicroService.MongoDB;

[ConnectionStringName(AuthMicroServiceDbProperties.ConnectionStringName)]
public class AuthMicroServiceMongoDbContext : AbpMongoDbContext, IAuthMicroServiceMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureAuthMicroService();
    }
}