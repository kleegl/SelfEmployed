using iMessengerCoreAPI.Models.Implementations;
using iMessengerCoreAPI.Models.Interfaces;
using iMessengerCoreAPI.Repositories.Implementations;
using iMessengerCoreAPI.Repositories.Interfaces;
using iMessengerCoreAPI.Services.Implementations;
using iMessengerCoreAPI.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "iMessengerCoreAPI", Version = "v1" });
});

builder.Services.AddTransient<IRGDialogsClients, RGDialogsClients>();
builder.Services.AddTransient<IRGDialogsClientsRepository, RGDialogsClientsRepository>();
builder.Services.AddTransient<IRGDialogsClientsService, RGDialogsClientsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "iMessengerCoreAPI";
        swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Listing v1");
        swaggerUIOptions.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
