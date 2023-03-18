using Videos.Api.Domain.Exceptions;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.ContentAggregate;

public class ContentRate : ValueObject
{
    public double Value { get; }

    public ContentRate(int value)
    {
        if (value is > 5 or < 0) throw new DomainException("Content rate must be between 0 and 5");

        Value = value;
    }

    protected ContentRate()
    {
    }
}
