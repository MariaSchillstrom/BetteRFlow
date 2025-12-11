using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddFormSubmissionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "FormSubmissions",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "AdressNyckelÖverlämning",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningAnsökanTill",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningAvgift",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AndrahandsuthyrningKrävergodkännande",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AndrahandsuthyrningVillkorUrl",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AntalGarageplatser",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalLaddplatser",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalLägenheter",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AntalParkeringsplatser",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvgiftInnefattarAnnat",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarBredband",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarHemförsäkring",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKabelTV",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKallvatten",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarKällare",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarVarmvatten",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvgiftInnefattarVärme",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Barnvagnsförråd",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bastu",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BeslutOmMedlemskap",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BredbandKundservice",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bredbandshastighet",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bredbandsleverantör",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrfNamn",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Byggnadsår",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cykelförråd",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DelatÄgande",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EkonomiskFörvaltare",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Elavtal",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ElavtalKommentar",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ElplintarPåMark",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Energideklaration",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EnergideklarationDatum",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraLokaler",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExtraLokalerKommentar",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighet",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsFörvaltare",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Festlokal",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "FriHöjdGarage",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GemensammaUtrymmennAnnat",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Gym",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gästlägenhet",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Hemsida",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "JuridiskPersonFårFörvärva",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JuridiskPersonKommentar",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KontaktEmail",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KontaktTelefon",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadGarageplats",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadGarageplatsElektricitet",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KostnadParkeringsplats",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laddkostnad",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedlemsansökanSkickasTill",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedlemskapsRutin",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinstaAndel",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NyckelÖverlämning",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organisationsnummer",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParkeringKontakt",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlanerardeReparationer",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenasteAvgiftsförändring",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StädningGemensamma",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Tvättstuga",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Uppvärmning",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VadSkasÖverlämnas",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ventilation",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ÄktaBrf",
                table: "FormSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Överlåtelseavgift",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressNyckelÖverlämning",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningAnsökanTill",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningAvgift",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningKrävergodkännande",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AndrahandsuthyrningVillkorUrl",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AntalGarageplatser",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AntalLaddplatser",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AntalLägenheter",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AntalParkeringsplatser",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarAnnat",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarBredband",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarHemförsäkring",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKabelTV",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKallvatten",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarKällare",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarVarmvatten",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "AvgiftInnefattarVärme",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Barnvagnsförråd",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Bastu",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "BeslutOmMedlemskap",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "BredbandKundservice",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Bredbandshastighet",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Bredbandsleverantör",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "BrfNamn",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Byggnadsår",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Cykelförråd",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "DelatÄgande",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "EkonomiskFörvaltare",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Elavtal",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ElavtalKommentar",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ElplintarPåMark",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Energideklaration",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "EnergideklarationDatum",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ExtraLokaler",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ExtraLokalerKommentar",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Fastighet",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "FastighetsFörvaltare",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Festlokal",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "FriHöjdGarage",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "GemensammaUtrymmennAnnat",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Gym",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Gästlägenhet",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Hemsida",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "JuridiskPersonFårFörvärva",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "JuridiskPersonKommentar",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "KontaktEmail",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "KontaktTelefon",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "KostnadGarageplats",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "KostnadGarageplatsElektricitet",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "KostnadParkeringsplats",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Laddkostnad",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "MedlemsansökanSkickasTill",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "MedlemskapsRutin",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "MinstaAndel",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "NyckelÖverlämning",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Organisationsnummer",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ParkeringKontakt",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "PlanerardeReparationer",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "SenasteAvgiftsförändring",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "StädningGemensamma",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Tvättstuga",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Uppvärmning",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "VadSkasÖverlämnas",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Ventilation",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ÄktaBrf",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Överlåtelseavgift",
                table: "FormSubmissions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FormSubmissions",
                newName: "ID");
        }
    }
}
