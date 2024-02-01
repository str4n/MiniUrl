using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniUrl.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class SetMaxLengthOfUrlCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "url",
                table: "ShortenedUrls",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "url",
                table: "ShortenedUrls",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);
        }
    }
}
