using System;
using Videos.Api.Domain.Exceptions;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.MediaAggregate;

public class Media : Entity, IAggregateRoot
{
    public string Title { get; }
    public string Description { get; }
    public bool IsExplicit { get; }
    public object Metadata { get; }
    public MediaType Type { get; }
    public MediaMetrics Metrics { get; }
    public TimeSpan Duration { get; }
    public DateTime ReleaseDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public Media(string title, string description, bool isExplicit, MediaType type, TimeSpan duration, DateTime releaseDate, MediaMetadata metadata = default)
    {
        if (description.Length > 2000) throw new DomainException($"{nameof(Description)} can't be more than 2000 words");

        if (type.Id == MediaType.Episode.Id && metadata is null) throw new DomainException("All episodes should have a metadata");

        SetId();
        Metrics = new MediaMetrics(0, 0, 0);
        Type = type;
        Title = title;
        Description = description;
        IsExplicit = isExplicit;
        Duration = duration;
        ReleaseDate = releaseDate;
        Metadata = metadata;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    protected Media()
    {
    }
}
