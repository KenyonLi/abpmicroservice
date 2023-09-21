using InternalGateway.Host;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddAppSettingsSecretsJson()
               .UseAutofac();
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json")
//                   // .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//                    .AddEnvironmentVariables(); 

builder.Services.AddApplication<InternalGatewayHostModule>();


//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
app.InitializeApplication();
await app.RunAsync();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
