using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.MediaAggregate;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class MediaEpisodeMetadataMap : IEntityTypeConfiguration<MediaEpisodeMetadata>
{
    public void Configure(EntityTypeBuilder<MediaEpisodeMetadata> builder)
    {
        builder.ToTable("media_episode_metadata");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(m => m.EpisodeNumber)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("episode_number")
            .IsRequired();

        builder
            .Property(m => m.SeasonNumber)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("season_number")
            .IsRequired();
    }
}
