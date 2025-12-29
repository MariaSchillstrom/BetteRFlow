using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class LaggtillAvvikelseSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FormularDatum",
                table: "Brfs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FormularInskickat",
                table: "Brfs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SenasteFormSubmissionId",
                table: "Brfs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BrfAvvikelser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrfId = table.Column<int>(type: "INTEGER", nullable: false),
                    Faltnamn = table.Column<string>(type: "TEXT", nullable: false),
                    VardeGrunddata = table.Column<string>(type: "TEXT", nullable: false),
                    VardeFormular = table.Column<string>(type: "TEXT", nullable: false),
                    Granskad = table.Column<bool>(type: "INTEGER", nullable: false),
                    SkapadDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FormSubmissionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrfAvvikelser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrfAvvikelser_Brfs_BrfId",
                        column: x => x.BrfId,
                        principalTable: "Brfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrfAvvikelser_FormSubmissions_FormSubmissionId",
                        column: x => x.FormSubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrfAvvikelser_BrfId",
                table: "BrfAvvikelser",
                column: "BrfId");

            migrationBuilder.CreateIndex(
                name: "IX_BrfAvvikelser_FormSubmissionId",
                table: "BrfAvvikelser",
                column: "FormSubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrfAvvikelser");

            migrationBuilder.DropColumn(
                name: "FormularDatum",
                table: "Brfs");

            migrationBuilder.DropColumn(
                name: "FormularInskickat",
                table: "Brfs");

            migrationBuilder.DropColumn(
                name: "SenasteFormSubmissionId",
                table: "Brfs");
        }
    }
}
