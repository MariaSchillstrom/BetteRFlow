using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class SplitBrfAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganisationsAdress",
                table: "Brfs",
                newName: "Postnummer");

            migrationBuilder.AddColumn<string>(
                name: "Gatuadress",
                table: "Brfs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ort",
                table: "Brfs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gatuadress",
                table: "Brfs");

            migrationBuilder.DropColumn(
                name: "Ort",
                table: "Brfs");

            migrationBuilder.RenameColumn(
                name: "Postnummer",
                table: "Brfs",
                newName: "OrganisationsAdress");
        }
    }
}
