using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UppdateradBrfStruktur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Organisationsnummer",
                table: "FormSubmissions",
                newName: "OrganisationsNummer");

            migrationBuilder.RenameColumn(
                name: "Fastighet",
                table: "FormSubmissions",
                newName: "Postnummer");

            migrationBuilder.RenameColumn(
                name: "BrfNamn",
                table: "FormSubmissions",
                newName: "Ort");

            migrationBuilder.RenameColumn(
                name: "Organisationsnummer",
                table: "Forms",
                newName: "OrganisationsNummer");

            migrationBuilder.RenameColumn(
                name: "Fastighet",
                table: "Forms",
                newName: "Postnummer");

            migrationBuilder.RenameColumn(
                name: "BrfNamn",
                table: "Forms",
                newName: "Ort");

            migrationBuilder.RenameColumn(
                name: "BrfNamn",
                table: "Brfs",
                newName: "ForeningensNamn");

            migrationBuilder.AlterColumn<string>(
                name: "KontaktTelefon",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Hemsida",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsOrt",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsPostnummer",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighetsadress",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighetsbeteckning",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeningensNamn",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gatuadress",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kortnamn",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KontaktTelefon",
                table: "Forms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Hemsida",
                table: "Forms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsOrt",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FastighetsPostnummer",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighetsadress",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fastighetsbeteckning",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeningensNamn",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gatuadress",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kortnamn",
                table: "Forms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kortnamn",
                table: "Brfs",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FastighetsOrt",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "FastighetsPostnummer",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Fastighetsadress",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Fastighetsbeteckning",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "ForeningensNamn",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Gatuadress",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "Kortnamn",
                table: "FormSubmissions");

            migrationBuilder.DropColumn(
                name: "FastighetsOrt",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FastighetsPostnummer",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Fastighetsadress",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Fastighetsbeteckning",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ForeningensNamn",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Gatuadress",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Kortnamn",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Kortnamn",
                table: "Brfs");

            migrationBuilder.RenameColumn(
                name: "OrganisationsNummer",
                table: "FormSubmissions",
                newName: "Organisationsnummer");

            migrationBuilder.RenameColumn(
                name: "Postnummer",
                table: "FormSubmissions",
                newName: "Fastighet");

            migrationBuilder.RenameColumn(
                name: "Ort",
                table: "FormSubmissions",
                newName: "BrfNamn");

            migrationBuilder.RenameColumn(
                name: "OrganisationsNummer",
                table: "Forms",
                newName: "Organisationsnummer");

            migrationBuilder.RenameColumn(
                name: "Postnummer",
                table: "Forms",
                newName: "Fastighet");

            migrationBuilder.RenameColumn(
                name: "Ort",
                table: "Forms",
                newName: "BrfNamn");

            migrationBuilder.RenameColumn(
                name: "ForeningensNamn",
                table: "Brfs",
                newName: "BrfNamn");

            migrationBuilder.AlterColumn<string>(
                name: "KontaktTelefon",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hemsida",
                table: "FormSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KontaktTelefon",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hemsida",
                table: "Forms",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
