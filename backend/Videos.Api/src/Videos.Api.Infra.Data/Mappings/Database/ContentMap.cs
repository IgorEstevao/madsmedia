using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.ContentAggregate;
using Videos.Api.Infra.Data.Mappings.Extensions;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class ContentMap : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable("content");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
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
            .Property(c => c.AlternateTitles)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("alternate_titles")
            .HasJsonConversion()
            .IsRequired();

        builder
            .Property(c => c.Description)
            .HasMaxLength(2000)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("description")
            .IsRequired();

        builder
            .Property(c => c.Favorites)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("favorites")
            .IsRequired();

        builder
            .Property(c => c.ReleaseDate)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("release_date")
            .IsRequired();

        builder
            .Property(c => c.CreatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("created_at")
            .IsRequired();

        builder
            .Property(c => c.UpdatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("updated_at")
            .IsRequired();

        builder
            .OwnsOne(c => c.Rate)
            .Property(r => r.Value)
            .HasColumnName("rate")
            .IsRequired();
    }
}
