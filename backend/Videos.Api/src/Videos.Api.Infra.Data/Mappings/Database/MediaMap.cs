using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.ContentAggregate;
using Videos.Api.Domain.Aggregates.MediaAggregate;
using Videos.Api.Infra.Data.Mappings.Extensions;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class MediaMap : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("media");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(c => c.Title)
            .HasMaxLength(200)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("title")
            .IsRequired();

        builder
            .Property(c => c.Description)
            .HasMaxLength(2000)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("description")
            .IsRequired();

        builder
            .Property(c => c.IsExplicit)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_explicit")
            .IsRequired();

        builder
            .Property(c => c.Duration)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("duration")
            .IsRequired();

        builder
            .Property(c => c.Metadata)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("metadata")
            .HasJsonConversion();

        builder
            .Property(c => c.ReleaseDate)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("release_date")
            .IsRequired();

        builder
            .Property(c => c.UpdatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("updated_at")
            .IsRequired();

        builder
            .Property(c => c.CreatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("created_at")
            .IsRequired();

        builder.OwnsOne(c => c.Metrics)
            .Property(m => m.Likes)
            .HasColumnName("likes")
            .IsRequired();

        builder.OwnsOne(c => c.Metrics)
            .Property(m => m.Dislikes)
            .HasColumnName("dislikes")
            .IsRequired();

        builder.OwnsOne(c => c.Metrics)
            .Property(m => m.Views)
            .HasColumnName("views")
            .IsRequired();

        builder.HasOne<MediaType>()
            .WithMany()
            .HasForeignKey("type_id")
            .IsRequired();

        builder.HasOne<Content>()
            .WithMany(c => c.Medias)
            .HasForeignKey("content_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
