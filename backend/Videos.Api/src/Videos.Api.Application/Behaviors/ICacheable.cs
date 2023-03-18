using System;

namespace Videos.Api.Application.Behaviors;

public interface ICacheable
{
    public string CacheKey { get; }
    public TimeSpan Expiration { get; }
}
