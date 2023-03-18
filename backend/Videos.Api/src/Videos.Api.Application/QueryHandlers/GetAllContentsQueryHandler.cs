using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Videos.Api.Application.Dtos.Response;
using Videos.Api.Application.Queries;
using Videos.Api.Domain.Enums;
using Videos.Api.Domain.Exceptions;
using Videos.Api.Infra.CrossCutting.Environments.Configurations;

namespace Videos.Api.Application.QueryHandlers;

public class GetAllContentsQueryHandler : QueryHandler<GetAllContentsQuery, IEnumerable<ContentResponse>>
{
    private readonly ILogger<GetAllContentsQueryHandler> _logger;

    public GetAllContentsQueryHandler(ApplicationConfiguration applicationConfiguration, IMediator bus, ILogger<GetAllContentsQueryHandler> logger) : base(applicationConfiguration, bus)
    {
        _logger = logger;
    }

    public override async Task<IEnumerable<ContentResponse>> Handle(GetAllContentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            using var db = GetDatabaseConnection();

            var sql = new StringBuilder(
                "SELECT c.title, c.description, c.favorites, c.release_date, c.rate, c.alternate_titles, c.created_at, c.updated_at, ct.name, s.name " +
                "FROM content c " +
                "JOIN content_category cc ON c.id = cc.content_id " +
                "JOIN category ct ON ct.id = cc.category_id " +
                "JOIN content_studio cs ON c.id = cs.content_id " +
                "JOIN studio s ON s.id = cs.studio_id "
            );

            if (request.CategoryIds is not null && request.CategoryIds.Any())
            {
                const string sqlToAppend = "ct.id IN @categoryIds";

                sql.Append(sql.ToString().Contains("WHERE") ? $"AND {sqlToAppend}" : $"WHERE {sqlToAppend}");
            }

            if (request.StudioIds is not null && request.StudioIds.Any())
            {
                const string sqlToAppend = "s.id IN @studioIds";

                sql.Append(sql.ToString().Contains("WHERE") ? $"AND {sqlToAppend}" : $"WHERE {sqlToAppend}");
            }

            // var contents = await db.QueryAsync<>(sql, () => { }, splitOn: "FirstName, TagId");

            return default;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Ocorreu um erro ao buscar todos os conteúdos #### Exception: {0} ####", e.ToString());
            await Bus.Publish(new ExceptionNotification("02", "Não foi possível buscar todos os conteúdos", ExceptionType.Server), cancellationToken);
            return default;
        }
    }
}
