using LKN.OrderDetailsServices;





var builder = WebApplication.CreateBuilder(args);

builder.Host.AddAppSettingsSecretsJson()
               .UseAutofac();
               //.UseSerilog();
await builder.AddApplicationAsync<OrderDetailsServicesModule>();

var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

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
