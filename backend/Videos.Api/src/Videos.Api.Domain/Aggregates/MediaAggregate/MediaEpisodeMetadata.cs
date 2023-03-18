namespace Videos.Api.Domain.Aggregates.MediaAggregate;

public class MediaEpisodeMetadata : MediaMetadata
{
    public int SeasonNumber { get; }
    public int EpisodeNumber { get; }

    public MediaEpisodeMetadata(int seasonNumber, int episodeNumber)
    {
        SeasonNumber = seasonNumber;
        EpisodeNumber = episodeNumber;
    }
}
