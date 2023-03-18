using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Videos.Api.Application.Queries;
using Videos.Api.Infra.CrossCutting.Environments.Configurations;
using MediatR;
using MySqlConnector;

namespace Videos.Api.Application.QueryHandlers;

public abstract class QueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : Query<TResponse>
{
    private readonly IDbConnection _dbConnection;
    protected readonly IMediator Bus;

    protected QueryHandler(ApplicationConfiguration applicationConfiguration, IMediator bus)
    {
        _dbConnection = new MySqlConnection(applicationConfiguration.ConnectionString);
        Bus = bus;
    }

    protected IDbConnection GetDatabaseConnection()
    {
        if (_dbConnection.State == ConnectionState.Closed)
        {
            _dbConnection.Open();
        }

        return _dbConnection;
    }

    protected void CloseDatabaseConnection()
    {
        if (_dbConnection.State is ConnectionState.Open or ConnectionState.Broken)
        {
            _dbConnection.Close();
        }
    }

    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}
