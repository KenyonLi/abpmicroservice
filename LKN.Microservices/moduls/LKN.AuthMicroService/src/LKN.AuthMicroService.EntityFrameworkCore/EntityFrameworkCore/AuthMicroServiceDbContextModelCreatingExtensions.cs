using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.EntityFrameworkCore;

namespace LKN.AuthMicroService.EntityFrameworkCore;

public static class AuthMicroServiceDbContextModelCreatingExtensions
{
    public static void ConfigureAuthMicroService(
        this ModelBuilder builder,Action<AuthMicroServiceModelBuilderConfigurationOptions> optionsAction=null)
    {
        Check.NotNull(builder, nameof(builder));
        //去掉前缀扩展
        var options = new AuthMicroServiceModelBuilderConfigurationOptions(
               AuthMicroServiceDbProperties.DbTablePrefix,
               AuthMicroServiceDbProperties.DbSchema
           );
        optionsAction?.Invoke(options);
        // 1、创建IdentityServer4表
        builder.ConfigureIdentityServer();

        // AbpIdentityServerDbProperties.DbTablePrefix = "";
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(AuthMicroServiceDbProperties.DbTablePrefix + "Questions", AuthMicroServiceDbProperties.DbSchema);

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
