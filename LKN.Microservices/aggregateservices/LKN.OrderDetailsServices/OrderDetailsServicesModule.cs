using Google.Protobuf.WellKnownTypes;
using LKN.Order;
using LKN.OrderDetailsServices.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Servicecomb.Saga.Omega.AspNetCore.Extensions;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ModelBinding.Metadata;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LKN.OrderDetailsServices
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(OrderHttpApiClientModule))]
    public class OrderDetailsServicesModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            context.Services.AddEndpointsApiExplorer();
            context.Services.AddSwaggerGen(c=>c.SwaggerDoc("v1",new OpenApiInfo { Title = "LKN.OrderDetailsServices", Version = "v1" }));
            var configuration = context.Services.GetConfiguration();

            // 1、使用CAP
            context.Services.AddCap(x =>
            {
                //1.1、使用RabbitMQ存储消息
                x.UseRabbitMQ(rb =>
                {
                    rb.HostName = configuration.GetSection("Cap").GetValue<string>("HostName");
                    rb.UserName = configuration.GetSection("Cap").GetValue<string>("UserName");
                    rb.Password = configuration.GetSection("Cap").GetValue<string>("Password");
                    rb.Port = configuration.GetSection("Cap").GetValue<int>("Port");
                    rb.VirtualHost = configuration.GetSection("Cap").GetValue<string>("VirtualHost");
                });

                // 1.2、存储消息
                //x.UseInMemoryStorage();
                x.UseEntityFramework<OrderDetailsDbContext>();
                x.UseMySql(configuration.GetConnectionString("OrderDetails"));

                // 1.3、添加发送消息失败重试（默认有重试，默认重试5次 前3次快速重试，16分钟再次重试）
                x.FailedRetryInterval = configuration.GetSection("Cap").GetValue<int>("FailedRetryInterval");
                x.FailedRetryCount = configuration.GetSection("Cap").GetValue<int>("FailedRetryCount");

                // 1.4、人工干预重试
                x.UseDashboard();
            });

            // 2、OrderDetailsDbContext添加到IOC容器
            context.Services.AddAbpDbContext<OrderDetailsDbContext>();

            // 3、配置MySQL
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });

            // 7、注册saga分布式事务
            context.Services.AddOmegaCore(option => {
                option.GrpcServerAddress = "localhost:8081"; // 1、协调中心地址  查看 配置文件 application.yaml
                option.InstanceId = "AggregateService-1";// 2、服务实例Id
                option.ServiceName = "AggregateService";// 3、服务名称
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LKN.OrderDetailsServices v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();


        }
    }
}
