namespace Videos.Api.Application.Behaviors;

public interface IInvalidateCache
{
    public string CacheKeyToInvalidate { get; }
}
