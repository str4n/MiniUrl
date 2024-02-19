using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniUrl.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RenamedUserStateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserState",
                schema: "url",
                table: "Users",
                newName: "State");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                schema: "url",
                table: "Users",
                newName: "UserState");
        }
    }
}
