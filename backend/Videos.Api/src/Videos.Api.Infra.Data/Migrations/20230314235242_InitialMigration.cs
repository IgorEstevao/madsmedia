using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Videos.Api.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "content",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    favorites = table.Column<int>(type: "int", nullable: false),
                    releasedate = table.Column<DateTime>(name: "release_date", type: "datetime(6)", nullable: false),
                    rate = table.Column<double>(type: "double", nullable: true),
                    alternatetitles = table.Column<string>(name: "alternate_titles", type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "media_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_type", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studio",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studio", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bookmarked_content",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    contentid = table.Column<Guid>(name: "content_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    userid = table.Column<Guid>(name: "user_id", type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookmarked_content", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookmarked_content_content_content_id",
                        column: x => x.contentid,
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "content_category",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(name: "category_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    contentid = table.Column<Guid>(name: "content_id", type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_category", x => new { x.categoryid, x.contentid });
                    table.ForeignKey(
                        name: "FK_content_category_category_category_id",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_content_category_content_content_id",
                        column: x => x.contentid,
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isexplicit = table.Column<bool>(name: "is_explicit", type: "tinyint(1)", nullable: false),
                    metadata = table.Column<string>(type: "json", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    likes = table.Column<int>(type: "int", nullable: true),
                    dislikes = table.Column<int>(type: "int", nullable: true),
                    views = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    releasedate = table.Column<DateTime>(name: "release_date", type: "datetime(6)", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "datetime(6)", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "datetime(6)", nullable: false),
                    contentid = table.Column<Guid>(name: "content_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    typeid = table.Column<int>(name: "type_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.id);
                    table.ForeignKey(
                        name: "FK_media_content_content_id",
                        column: x => x.contentid,
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_media_media_type_type_id",
                        column: x => x.typeid,
                        principalTable: "media_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "content_studio",
                columns: table => new
                {
                    contentid = table.Column<Guid>(name: "content_id", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    studioid = table.Column<Guid>(name: "studio_id", type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_studio", x => new { x.contentid, x.studioid });
                    table.ForeignKey(
                        name: "FK_content_studio_content_content_id",
                        column: x => x.contentid,
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_content_studio_studio_studio_id",
                        column: x => x.studioid,
                        principalTable: "studio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "media_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Movie" },
                    { 2, "Episode" },
                    { 3, "Ova" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookmarked_content_content_id",
                table: "bookmarked_content",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_category_content_id",
                table: "content_category",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_studio_studio_id",
                table: "content_studio",
                column: "studio_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_content_id",
                table: "media",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_type_id",
                table: "media",
                column: "type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookmarked_content");

            migrationBuilder.DropTable(
                name: "content_category");

            migrationBuilder.DropTable(
                name: "content_studio");

            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "studio");

            migrationBuilder.DropTable(
                name: "content");

            migrationBuilder.DropTable(
                name: "media_type");
        }
    }
}
