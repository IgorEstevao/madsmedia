using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Videos.Api.Domain.Aggregates.BookmarkedContentAggregate;
using Videos.Api.Domain.Aggregates.ContentAggregate;

namespace Videos.Api.Infra.Data.Mappings.Database;

public class BookmarkedContentMap : IEntityTypeConfiguration<BookmarkedContent>
{
    public void Configure(EntityTypeBuilder<BookmarkedContent> builder)
    {
        builder.ToTable("bookmarked_content");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.UserId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(c => c.ContentId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("content_id")
            .IsRequired();

        builder.HasOne<Content>()
            .WithMany()
            .HasForeignKey(c => c.ContentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
