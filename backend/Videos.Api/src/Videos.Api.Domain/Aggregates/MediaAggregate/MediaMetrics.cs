using Videos.Api.Domain.Exceptions;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Domain.Aggregates.MediaAggregate;

public class MediaMetrics : ValueObject
{
    public int Likes { get; private set; }
    public int Dislikes { get; private set; }
    public int Views { get; private set; }

    public MediaMetrics(int likes, int dislikes, int views)
    {
        if (likes < 0 || dislikes < 0 || views < 0) throw new DomainException("Metrics parameters should not be below 0");

        Likes = likes;
        Dislikes = dislikes;
        Views = views;
    }

    public void IncrementLike()
    {
        Likes++;
    }

    public void IncrementDislike()
    {
        Dislikes++;
    }

    public void IncrementViews()
    {
        Views++;
    }
}
