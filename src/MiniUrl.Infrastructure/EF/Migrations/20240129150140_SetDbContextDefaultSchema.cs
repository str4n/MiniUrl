using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniUrl.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class SetDbContextDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "url");

            migrationBuilder.RenameTable(
                name: "ShortenedUrls",
                newName: "ShortenedUrls",
                newSchema: "url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ShortenedUrls",
                schema: "url",
                newName: "ShortenedUrls");
        }
    }
}
