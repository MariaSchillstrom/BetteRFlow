using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class RenameNamnToBrfNamn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Namn",
                table: "Brfs",
                newName: "BrfNamn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrfNamn",
                table: "Brfs",
                newName: "Namn");
        }
    }
}
