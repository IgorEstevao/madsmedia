using Videos.Api.Application.CommandHandlers;
using Videos.Api.Application.Validations;
using MediatR;
using Videos.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Videos.Api.Infra.CrossCutting.IoC.Configurations;
using Videos.Api.Infra.CrossCutting.IoC.Configurations.Authentication;
using Videos.Api.Infra.CrossCutting.IoC.Configurations.Logging;
using Videos.Api.Infra.CrossCutting.IoC.Configurations.HealthCheck;
using FluentValidation;
using Serilog;
using Videos.Api.Application.QueryHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Validator<>), ServiceLifetime.Singleton);
builder.Services.AddCustomLogging(builder.Configuration);
builder.Services.AddCustomAuthentication();
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddAutoMapper();
builder.Services.AddDependencyInjectionSetup(builder.Configuration);
builder.Services.AddMediatR(typeof(CommandHandler<,>));
builder.Services.AddScoped<GlobalExceptionFilterAttribute>();
builder.Services.AddDatabaseSetup();
builder.Services.AddControllers();

builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

app.UseLoggingMiddlewares();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(corsBuilder =>
{
    corsBuilder.WithOrigins("*");
    corsBuilder.AllowAnyOrigin();
    corsBuilder.AllowAnyMethod();
    corsBuilder.AllowAnyHeader();
});

app.UseRouting();

app.UseAuthorization();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerSetup(apiVersionDescriptionProvider);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthCheck();
});

app.Run();
