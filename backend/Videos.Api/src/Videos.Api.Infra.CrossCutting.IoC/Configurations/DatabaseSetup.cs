using System;
using Videos.Api.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Videos.Api.Infra.CrossCutting.IoC.Configurations;

public static class DatabaseSetup
{
	public static void AddDatabaseSetup(this IServiceCollection services)
	{
        ArgumentNullException.ThrowIfNull(services);

		services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
	}
}
