using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.TagAggregate;

public class Category : Entity, IAggregateRoot
{
    public string Name { get; }

    public Category(string name)
    {
        SetId();
        Name = name.ToUpperInvariant();
    }
}
