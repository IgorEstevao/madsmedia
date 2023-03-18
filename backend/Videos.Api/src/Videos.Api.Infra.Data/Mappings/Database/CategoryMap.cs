using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.ContentAggregate;
using Videos.Api.Domain.Aggregates.TagAggregate;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("name")
            .IsRequired();

        builder.HasMany<Content>()
            .WithMany(c => c.Categories)
            .UsingEntity<Dictionary<string, object>>("ContentCategories",
                x => x.HasOne<Content>().WithMany().HasForeignKey("content_id"),
                x => x.HasOne<Category>().WithMany().HasForeignKey("category_id"),
                x => x.ToTable("content_category")
            );
    }
}
