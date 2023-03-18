﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Videos.Api.Infra.Data.Context;

#nullable disable

namespace Videos.Api.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ContentCategories", b =>
                {
                    b.Property<Guid>("category_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("content_id")
                        .HasColumnType("char(36)");

                    b.HasKey("category_id", "content_id");

                    b.HasIndex("content_id");

                    b.ToTable("content_category", (string)null);
                });

            modelBuilder.Entity("ContentStudios", b =>
                {
                    b.Property<Guid>("content_id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("studio_id")
                        .HasColumnType("char(36)");

                    b.HasKey("content_id", "studio_id");

                    b.HasIndex("studio_id");

                    b.ToTable("content_studio", (string)null);
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.BookmarkedContentAggregate.BookmarkedContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("char(36)")
                        .HasColumnName("content_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("bookmarked_content", (string)null);
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.ContentAggregate.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("AlternateTitles")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("alternate_titles");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<int>("Favorites")
                        .HasColumnType("int")
                        .HasColumnName("favorites");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("content", (string)null);
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.MediaAggregate.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time(6)")
                        .HasColumnName("duration");

                    b.Property<bool>("IsExplicit")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_explicit");

                    b.Property<string>("Metadata")
                        .HasColumnType("json")
                        .HasColumnName("metadata");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("content_id")
                        .HasColumnType("char(36)");

                    b.Property<int>("type_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("content_id");

                    b.HasIndex("type_id");

                    b.ToTable("media", (string)null);
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.MediaAggregate.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("media_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Movie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Episode"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ova"
                        });
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.StudioAggregate.Studio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("studio", (string)null);
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.TagAggregate.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("ContentCategories", b =>
                {
                    b.HasOne("Videos.Api.Domain.Aggregates.TagAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Videos.Api.Domain.Aggregates.ContentAggregate.Content", null)
                        .WithMany()
                        .HasForeignKey("content_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContentStudios", b =>
                {
                    b.HasOne("Videos.Api.Domain.Aggregates.ContentAggregate.Content", null)
                        .WithMany()
                        .HasForeignKey("content_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Videos.Api.Domain.Aggregates.StudioAggregate.Studio", null)
                        .WithMany()
                        .HasForeignKey("studio_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.BookmarkedContentAggregate.BookmarkedContent", b =>
                {
                    b.HasOne("Videos.Api.Domain.Aggregates.ContentAggregate.Content", null)
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.ContentAggregate.Content", b =>
                {
                    b.OwnsOne("Videos.Api.Domain.Aggregates.ContentAggregate.ContentRate", "Rate", b1 =>
                        {
                            b1.Property<Guid>("ContentId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasColumnType("double")
                                .HasColumnName("rate");

                            b1.HasKey("ContentId");

                            b1.ToTable("content");

                            b1.WithOwner()
                                .HasForeignKey("ContentId");
                        });

                    b.Navigation("Rate");
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.MediaAggregate.Media", b =>
                {
                    b.HasOne("Videos.Api.Domain.Aggregates.ContentAggregate.Content", null)
                        .WithMany("Medias")
                        .HasForeignKey("content_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Videos.Api.Domain.Aggregates.MediaAggregate.MediaType", null)
                        .WithMany()
                        .HasForeignKey("type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Videos.Api.Domain.Aggregates.MediaAggregate.MediaMetrics", "Metrics", b1 =>
                        {
                            b1.Property<Guid>("MediaId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Dislikes")
                                .HasColumnType("int")
                                .HasColumnName("dislikes");

                            b1.Property<int>("Likes")
                                .HasColumnType("int")
                                .HasColumnName("likes");

                            b1.Property<int>("Views")
                                .HasColumnType("int")
                                .HasColumnName("views");

                            b1.HasKey("MediaId");

                            b1.ToTable("media");

                            b1.WithOwner()
                                .HasForeignKey("MediaId");
                        });

                    b.Navigation("Metrics");
                });

            modelBuilder.Entity("Videos.Api.Domain.Aggregates.ContentAggregate.Content", b =>
                {
                    b.Navigation("Medias");
                });
#pragma warning restore 612, 618
        }
    }
}
