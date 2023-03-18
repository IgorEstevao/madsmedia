using System.Linq;
using System.Threading.Tasks;
using Videos.Api.Domain.SeedWork;
using Videos.Api.Infra.Data.Context;
using MediatR;

namespace Videos.Api.Infra.Data;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationDbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents);

        domainEntities
            .ForEach(entity => entity.Entity.ClearDomainEvent());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
