using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.MediaAggregate;
using Videos.Api.Domain.SeedWork;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class MediaTypeMap : IEntityTypeConfiguration<MediaType>
{
    public void Configure(EntityTypeBuilder<MediaType> builder)
    {
        builder.ToTable("media_type");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(m => m.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("name")
            .IsRequired();

        builder.HasData(Enumeration.GetAll<MediaType>());
    }
}
