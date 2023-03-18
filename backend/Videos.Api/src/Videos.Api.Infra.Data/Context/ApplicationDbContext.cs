using System;
using System.Threading;
using System.Threading.Tasks;
using Videos.Api.Infra.CrossCutting.Environments.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Videos.Api.Infra.Data.Mappings.Database;

namespace Videos.Api.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IMediator _bus;
    private readonly ApplicationConfiguration _applicationConfiguration;

    public ApplicationDbContext()
    {

    }
    //
    // public ApplicationDbContext(IOptions<ApplicationConfiguration> applicationConfiguration)
    // {
    //     _applicationConfiguration = applicationConfiguration.Value;
    // }
    //
    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<ApplicationConfiguration> applicationConfiguration) : base(options)
    // {
    //     _applicationConfiguration = applicationConfiguration.Value;
    // }
    //
    // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator, IOptions<ApplicationConfiguration> applicationConfiguration) : base(options)
    // {
    //     ArgumentNullException.ThrowIfNull(mediator);
    //     _bus = mediator;
    //     _applicationConfiguration = applicationConfiguration.Value;
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql("Server=localhost;Database=video;Uid=root;Pwd=root;", ServerVersion.AutoDetect("Server=localhost;Database=video;Uid=root;Pwd=root;"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MediaMap());
        modelBuilder.ApplyConfiguration(new StudioMap());
        modelBuilder.ApplyConfiguration(new ContentMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new MediaTypeMap());
        modelBuilder.ApplyConfiguration(new BookmarkedContentMap());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events collection.
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
        await _bus.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
        // performed through the DbContext will be committed
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
