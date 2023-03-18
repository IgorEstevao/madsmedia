using System;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.BookmarkedContentAggregate;

public class BookmarkedContent : Entity, IAggregateRoot
{
    public Guid ContentId { get; }
    public Guid UserId { get; }
    public DateTime CreatedAt { get; }

    public BookmarkedContent(Guid contentId, Guid userId)
    {
        ContentId = contentId;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
}
