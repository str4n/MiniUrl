using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniUrl.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedShortenedUrlExpiryDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Expiry",
                schema: "url",
                table: "ShortenedUrls",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expiry",
                schema: "url",
                table: "ShortenedUrls");
        }
    }
}
