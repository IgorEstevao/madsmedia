using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.MediaAggregate;

public class MediaType : Enumeration
{
    public static readonly MediaType Movie = new(1, nameof(Movie));
    public static readonly MediaType Episode = new(2, nameof(Episode));
    public static readonly MediaType Ova = new(3, nameof(Ova));

    public MediaType(int id, string name) : base(id, name)
    {
    }
}
