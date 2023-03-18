using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Videos.Api.Infra.CrossCutting.IoC.Configurations;

public static class DependencyInjectionSetup
{
	public static void AddDependencyInjectionSetup(this IServiceCollection services, IConfiguration configuration)
	{
        ArgumentNullException.ThrowIfNull(services);

		NativeInjectorBootstrapper.RegisterServices(services, configuration);
	}
}
