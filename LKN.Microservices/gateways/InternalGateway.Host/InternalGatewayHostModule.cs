using InternalGateway.Host.LoadBalancers;
using LKN.Microservices.ELK;
using LKN.Microservices.Infrastructure;
using LKN.Order;
using LKN.Product;
using Microsoft.OpenApi.Models;
using Ocelot.Cache.CacheManager;
using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Ocelot.ServiceDiscovery.Providers;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace InternalGateway.Host
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(OrderHttpApiModule),
        typeof(ProductHttpApiModule),
        typeof(ElaticsearchLogstashKibanaModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(InfrastructureModule)
      )]
    public class InternalGatewayHostModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var configuration = context.Services.GetConfiguration();

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Gateway API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
            //扩展自定义 随机负载均衡
            Func<IServiceProvider, DownstreamRoute, IServiceDiscoveryProvider, RandomLoadBalancer> loadBalancerFactoryFunc = (serviceProvider, Route, serviceDiscoveryProvider)
              => new RandomLoadBalancer(serviceDiscoveryProvider.Get);

            // 1、添加ocelot
            context.Services.AddOcelot(configuration)
                .AddCustomLoadBalancer<RandomLoadBalancer>(loadBalancerFactoryFunc)
                .AddPolly()
                .AddConsul();

            // 1、添加添加身份验证
            //context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //                .AddIdentityServerAuthentication("InternalGateway-key", options =>
            //                {
            //                    // 1、微服务认证
            //                    options.Authority = "https://localhost:44315"; // 1、认证中心地址
            //                    options.ApiName = "InternalGateway"; // 2、api名称(项目具体名称)
            //                    options.RequireHttpsMetadata = false; // 3、https元数据，不需要
            //                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAbpClaimsMap();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Internal Gateway API");
            });

            app.MapWhen(
                ctx =>
                    ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
                    ctx.Request.Path.ToString().StartsWith("/Abp/") ||
                    ctx.Request.Path.ToString().StartsWith("/Test/"),
                app2 =>
                {
                    app2.UseRouting();
                    app2.UseConfiguredEndpoints();
                }
            );
            //app.UseOcelotSwagger();
            // 2、使用ocelot
            app.UseOcelot().Wait();
            
        }
    }
}
