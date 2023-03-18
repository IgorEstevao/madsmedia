using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.ContentAggregate;
using Videos.Api.Domain.Aggregates.StudioAggregate;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class StudioMap : IEntityTypeConfiguration<Studio>
{
    public void Configure(EntityTypeBuilder<Studio> builder)
    {
        builder.ToTable("studio");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(c => c.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("name")
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

        builder.HasMany<Content>()
            .WithMany(c => c.Studios)
            .UsingEntity<Dictionary<string, object>>("ContentStudios",
                x => x.HasOne<Content>().WithMany().HasForeignKey("content_id"),
                x => x.HasOne<Studio>().WithMany().HasForeignKey("studio_id"),
                x => x.ToTable("content_studio")
            );
    }
}
