using System;
using Videos.Api.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Videos.Api.Infra.CrossCutting.IoC.Configurations;

public static class AutoMapperSetup
{
	public static void AddAutoMapper(this IServiceCollection services)
	{
        ArgumentNullException.ThrowIfNull(services);

		services.AddAutoMapper(typeof(MappingProfile));
	}
}
