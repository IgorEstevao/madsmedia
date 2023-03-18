using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Videos.Api.Application.Dtos.Response;
using Videos.Api.Application.Queries;
using Videos.Api.Domain.Enums;
using Videos.Api.Domain.Exceptions;
using Videos.Api.Infra.CrossCutting.Environments.Configurations;

namespace Videos.Api.Application.QueryHandlers;

public class GetCategoriesQueryHandler : QueryHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    private readonly ILogger<GetCategoriesQueryHandler> _logger;

    public GetCategoriesQueryHandler(IOptions<ApplicationConfiguration> applicationConfiguration, IMediator bus, ILogger<GetCategoriesQueryHandler> logger) : base(applicationConfiguration.Value, bus)
    {
        _logger = logger;
    }

    public override async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            using var db = GetDatabaseConnection();

            const string sql = "SELECT id, name FROM category";

            return await db.QueryAsync<CategoryResponse>(sql);
        }
        catch (Exception e)
        {
            _logger.LogCritical("Ocorreu um erro ao buscar as categorias #### Exception: {0} ####", e.ToString());
            await Bus.Publish(new ExceptionNotification("01", "Não foi possível buscar as categorias", ExceptionType.Server), cancellationToken);
            return default;
        }
    }
}
