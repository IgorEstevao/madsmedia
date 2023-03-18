using System;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.StudioAggregate;

public class Studio : Entity, IAggregateRoot
{
    public string Name { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public Studio(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
}
