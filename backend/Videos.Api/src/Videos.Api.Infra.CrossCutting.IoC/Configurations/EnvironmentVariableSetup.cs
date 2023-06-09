﻿using System;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Videos.Api.Infra.CrossCutting.IoC.Configurations;

public static class EnvironmentVariableSetup
{
    public static void AddEnvironmentVariableSection<T>(this IServiceCollection services, IConfiguration configuration, string sectionName) where T : class
    {
        services
            .AddOptions<T>()
            .Bind(configuration.GetRequiredSection(sectionName))
            .ValidateFluently()
            .ValidateOnStart();
    }

    private static OptionsBuilder<TOptions> ValidateFluently<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(s => new FluentValidationOptions<TOptions>(optionsBuilder.Name, s.GetRequiredService<IValidator<TOptions>>()));
        return optionsBuilder;
    }
}

public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IValidator<TOptions> _validator;
    public string Name { get; }

    public FluentValidationOptions(string name, IValidator<TOptions> validator)
    {
        Name = name;
        _validator = validator;
    }

    public ValidateOptionsResult Validate(string name, TOptions options)
    {
        if (Name != null && Name != name)
        {
            return ValidateOptionsResult.Skip;
        }

        ArgumentNullException.ThrowIfNull(options);

        var validationResult = _validator.Validate(options);

        if (validationResult.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var errors = validationResult.Errors.Select(x => $"Options validation failed for [{x.PropertyName}] with error: [{x.ErrorMessage}]");
        return ValidateOptionsResult.Fail(errors);
    }
}
