using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFastighet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fastigheter_Brfs_BrfId",
                table: "Fastigheter");

            migrationBuilder.DropIndex(
                name: "IX_Fastigheter_BrfId",
                table: "Fastigheter");

            migrationBuilder.DropColumn(
                name: "BrfId",
                table: "Fastigheter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrfId",
                table: "Fastigheter",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fastigheter_BrfId",
                table: "Fastigheter",
                column: "BrfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fastigheter_Brfs_BrfId",
                table: "Fastigheter",
                column: "BrfId",
                principalTable: "Brfs",
                principalColumn: "Id");
        }
    }
}
