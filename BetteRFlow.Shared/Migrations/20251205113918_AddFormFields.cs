using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddFormFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Forms",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "AdressNyckelÖverlämning",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningAnsökanTill",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningAvgift",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AndrahandsuthyrningKrävergodkännande",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningVillkorUrl",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AntalGarageplatser",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalLaddplatser",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalLägenheter",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalParkeringsplatser",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvgiftInnefattarAnnat",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarBredband",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarHemförsäkring",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKabelTV",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKallvatten",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKällare",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarVarmvatten",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarVärme",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Barnvagnsförråd",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bastu",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BeslutOmMedlemskap",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BredbandKundservice",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bredbandshastighet",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bredbandsleverantör",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrfId",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrfNamn",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Byggnadsår",
                table: "Forms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Cykelförråd",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelatÄgande",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EkonomiskFörvaltare",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Elavtal",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElavtalKommentar",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ElplintarPåMark",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Energideklaration",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EnergideklarationDatum",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraLokaler",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraLokalerKommentar",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighet",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsFörvaltare",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Festlokal",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "FriHöjdGarage",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GemensammaUtrymmennAnnat",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Gym",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gästlägenhet",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Hemsida",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "JuridiskPersonFårFörvärva",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JuridiskPersonKommentar",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KontaktEmail",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KontaktTelefon",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadGarageplats",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadGarageplatsElektricitet",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadParkeringsplats",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laddkostnad",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedlemsansökanSkickasTill",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedlemskapsRutin",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinstaAndel",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NyckelÖverlämning",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organisationsnummer",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParkeringKontakt",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlanerardeReparationer",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenasteAvgiftsförändring",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StädningGemensamma",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Tvättstuga",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uppvärmning",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VadSkasÖverlämnas",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ventilation",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ÄktaBrf",
                table: "Forms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Överlåtelseavgift",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_BrfId",
                table: "Forms",
                column: "BrfId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserId",
                table: "Forms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Brfs_BrfId",
                table: "Forms",
                column: "BrfId",
                principalTable: "Brfs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Users_UserId",
                table: "Forms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Brfs_BrfId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Users_UserId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_BrfId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_UserId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AdressNyckelÖverlämning",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningAnsökanTill",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningAvgift",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningKrävergodkännande",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningVillkorUrl",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AntalGarageplatser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AntalLaddplatser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AntalLägenheter",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AntalParkeringsplatser",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarAnnat",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarBredband",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarHemförsäkring",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKabelTV",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKallvatten",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKällare",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarVarmvatten",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarVärme",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Barnvagnsförråd",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Bastu",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "BeslutOmMedlemskap",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "BredbandKundservice",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Bredbandshastighet",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Bredbandsleverantör",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "BrfId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "BrfNamn",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Byggnadsår",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Cykelförråd",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "DelatÄgande",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "EkonomiskFörvaltare",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Elavtal",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ElavtalKommentar",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ElplintarPåMark",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Energideklaration",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "EnergideklarationDatum",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ExtraLokaler",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ExtraLokalerKommentar",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Fastighet",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FastighetsFörvaltare",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Festlokal",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FriHöjdGarage",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "GemensammaUtrymmennAnnat",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Gym",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Gästlägenhet",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Hemsida",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "JuridiskPersonFårFörvärva",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "JuridiskPersonKommentar",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "KontaktEmail",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "KontaktTelefon",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "KostnadGarageplats",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "KostnadGarageplatsElektricitet",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "KostnadParkeringsplats",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Laddkostnad",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "MedlemsansökanSkickasTill",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "MedlemskapsRutin",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "MinstaAndel",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "NyckelÖverlämning",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Organisationsnummer",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ParkeringKontakt",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "PlanerardeReparationer",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "SenasteAvgiftsförändring",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "StädningGemensamma",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Tvättstuga",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Uppvärmning",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "VadSkasÖverlämnas",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Ventilation",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ÄktaBrf",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Överlåtelseavgift",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Forms",
                newName: "ID");
        }
    }
}
