using AXA.Mandiri.Technical.Test.Application;
using AXA.Mandiri.Technical.Test.Infrastructure;
using AXA.Mandiri.Technical.Test.Infrastructure.Logging;
using AXA.Mandiri.Technical.Test.API;
using AXA.Mandiri.Technical.Test.API.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddSerilogLogging();

builder.Services.AddApiServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
