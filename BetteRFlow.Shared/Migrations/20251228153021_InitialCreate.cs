using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetteRFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Namn = table.Column<string>(type: "TEXT", nullable: false),
                    OrganisationsNummer = table.Column<string>(type: "TEXT", nullable: false),
                    Gatuadress = table.Column<string>(type: "TEXT", nullable: false),
                    Postnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Ort = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktEmail = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "TEXT", nullable: true),
                    Hemsida = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Realtor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuinessName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realtor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrfId = table.Column<int>(type: "INTEGER", nullable: true),
                    Fastighet = table.Column<string>(type: "TEXT", nullable: false),
                    Organisationsnummer = table.Column<string>(type: "TEXT", nullable: false),
                    BrfNamn = table.Column<string>(type: "TEXT", nullable: false),
                    Byggnadsår = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalLägenheter = table.Column<int>(type: "INTEGER", nullable: true),
                    ÄktaBrf = table.Column<bool>(type: "INTEGER", nullable: false),
                    EkonomiskFörvaltare = table.Column<string>(type: "TEXT", nullable: false),
                    FastighetsFörvaltare = table.Column<string>(type: "TEXT", nullable: false),
                    MedlemskapsRutin = table.Column<string>(type: "TEXT", nullable: false),
                    JuridiskPersonFårFörvärva = table.Column<bool>(type: "INTEGER", nullable: false),
                    JuridiskPersonKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    BeslutOmMedlemskap = table.Column<string>(type: "TEXT", nullable: false),
                    MedlemsansökanSkickasTill = table.Column<string>(type: "TEXT", nullable: false),
                    DelatÄgande = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinstaAndel = table.Column<string>(type: "TEXT", nullable: false),
                    Överlåtelseavgift = table.Column<decimal>(type: "TEXT", nullable: true),
                    AvgiftInnefattarVärme = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarVarmvatten = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKallvatten = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKabelTV = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarBredband = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarHemförsäkring = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKällare = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarAnnat = table.Column<string>(type: "TEXT", nullable: false),
                    SenasteAvgiftsförändring = table.Column<string>(type: "TEXT", nullable: false),
                    Bredbandsleverantör = table.Column<string>(type: "TEXT", nullable: false),
                    Bredbandshastighet = table.Column<string>(type: "TEXT", nullable: false),
                    BredbandKundservice = table.Column<string>(type: "TEXT", nullable: false),
                    Uppvärmning = table.Column<string>(type: "TEXT", nullable: false),
                    Ventilation = table.Column<string>(type: "TEXT", nullable: false),
                    Elavtal = table.Column<string>(type: "TEXT", nullable: false),
                    ElavtalKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    AntalGarageplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalParkeringsplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalLaddplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    FriHöjdGarage = table.Column<decimal>(type: "TEXT", nullable: true),
                    ElplintarPåMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    KostnadParkeringsplats = table.Column<decimal>(type: "TEXT", nullable: true),
                    KostnadGarageplats = table.Column<decimal>(type: "TEXT", nullable: true),
                    KostnadGarageplatsElektricitet = table.Column<decimal>(type: "TEXT", nullable: true),
                    Laddkostnad = table.Column<string>(type: "TEXT", nullable: false),
                    ParkeringKontakt = table.Column<string>(type: "TEXT", nullable: false),
                    Cykelförråd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Barnvagnsförråd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gästlägenhet = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tvättstuga = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bastu = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gym = table.Column<bool>(type: "INTEGER", nullable: false),
                    Festlokal = table.Column<bool>(type: "INTEGER", nullable: false),
                    GemensammaUtrymmennAnnat = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraLokaler = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraLokalerKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    StädningGemensamma = table.Column<string>(type: "TEXT", nullable: false),
                    NyckelÖverlämning = table.Column<string>(type: "TEXT", nullable: false),
                    VadSkasÖverlämnas = table.Column<string>(type: "TEXT", nullable: false),
                    AdressNyckelÖverlämning = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningKrävergodkännande = table.Column<bool>(type: "INTEGER", nullable: false),
                    AndrahandsuthyrningAvgift = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningAnsökanTill = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningVillkorUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PlanerardeReparationer = table.Column<string>(type: "TEXT", nullable: false),
                    Energideklaration = table.Column<bool>(type: "INTEGER", nullable: false),
                    EnergideklarationDatum = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktEmail = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "TEXT", nullable: false),
                    Hemsida = table.Column<string>(type: "TEXT", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubmissions_Brfs_BrfId",
                        column: x => x.BrfId,
                        principalTable: "Brfs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fornamn = table.Column<string>(type: "TEXT", nullable: false),
                    Efternamn = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BrfId = table.Column<int>(type: "INTEGER", nullable: true),
                    Firma = table.Column<string>(type: "TEXT", nullable: true),
                    RealtorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Brfs_BrfId",
                        column: x => x.BrfId,
                        principalTable: "Brfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Realtor_RealtorId",
                        column: x => x.RealtorId,
                        principalTable: "Realtor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BrfId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fastighet = table.Column<string>(type: "TEXT", nullable: false),
                    Organisationsnummer = table.Column<string>(type: "TEXT", nullable: false),
                    BrfNamn = table.Column<string>(type: "TEXT", nullable: false),
                    Byggnadsår = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalLägenheter = table.Column<int>(type: "INTEGER", nullable: true),
                    ÄktaBrf = table.Column<bool>(type: "INTEGER", nullable: false),
                    EkonomiskFörvaltare = table.Column<string>(type: "TEXT", nullable: false),
                    FastighetsFörvaltare = table.Column<string>(type: "TEXT", nullable: false),
                    MedlemskapsRutin = table.Column<string>(type: "TEXT", nullable: false),
                    JuridiskPersonFårFörvärva = table.Column<bool>(type: "INTEGER", nullable: false),
                    JuridiskPersonKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    BeslutOmMedlemskap = table.Column<string>(type: "TEXT", nullable: false),
                    MedlemsansökanSkickasTill = table.Column<string>(type: "TEXT", nullable: false),
                    DelatÄgande = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinstaAndel = table.Column<string>(type: "TEXT", nullable: false),
                    Överlåtelseavgift = table.Column<decimal>(type: "TEXT", nullable: true),
                    AvgiftInnefattarVärme = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarVarmvatten = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKallvatten = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKabelTV = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarBredband = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarHemförsäkring = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarKällare = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvgiftInnefattarAnnat = table.Column<string>(type: "TEXT", nullable: false),
                    SenasteAvgiftsförändring = table.Column<string>(type: "TEXT", nullable: false),
                    Bredbandsleverantör = table.Column<string>(type: "TEXT", nullable: false),
                    Bredbandshastighet = table.Column<string>(type: "TEXT", nullable: false),
                    BredbandKundservice = table.Column<string>(type: "TEXT", nullable: false),
                    Uppvärmning = table.Column<string>(type: "TEXT", nullable: false),
                    Ventilation = table.Column<string>(type: "TEXT", nullable: false),
                    Elavtal = table.Column<string>(type: "TEXT", nullable: false),
                    ElavtalKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    AntalGarageplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalParkeringsplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    AntalLaddplatser = table.Column<int>(type: "INTEGER", nullable: true),
                    FriHöjdGarage = table.Column<decimal>(type: "TEXT", nullable: true),
                    ElplintarPåMark = table.Column<bool>(type: "INTEGER", nullable: false),
                    KostnadParkeringsplats = table.Column<decimal>(type: "TEXT", nullable: true),
                    KostnadGarageplats = table.Column<decimal>(type: "TEXT", nullable: true),
                    KostnadGarageplatsElektricitet = table.Column<decimal>(type: "TEXT", nullable: true),
                    Laddkostnad = table.Column<string>(type: "TEXT", nullable: false),
                    ParkeringKontakt = table.Column<string>(type: "TEXT", nullable: false),
                    Cykelförråd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Barnvagnsförråd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gästlägenhet = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tvättstuga = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bastu = table.Column<bool>(type: "INTEGER", nullable: false),
                    Gym = table.Column<bool>(type: "INTEGER", nullable: false),
                    Festlokal = table.Column<bool>(type: "INTEGER", nullable: false),
                    GemensammaUtrymmennAnnat = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraLokaler = table.Column<string>(type: "TEXT", nullable: false),
                    ExtraLokalerKommentar = table.Column<string>(type: "TEXT", nullable: false),
                    StädningGemensamma = table.Column<string>(type: "TEXT", nullable: false),
                    NyckelÖverlämning = table.Column<string>(type: "TEXT", nullable: false),
                    VadSkasÖverlämnas = table.Column<string>(type: "TEXT", nullable: false),
                    AdressNyckelÖverlämning = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningKrävergodkännande = table.Column<bool>(type: "INTEGER", nullable: false),
                    AndrahandsuthyrningAvgift = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningAnsökanTill = table.Column<string>(type: "TEXT", nullable: false),
                    AndrahandsuthyrningVillkorUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PlanerardeReparationer = table.Column<string>(type: "TEXT", nullable: false),
                    Energideklaration = table.Column<bool>(type: "INTEGER", nullable: false),
                    EnergideklarationDatum = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktEmail = table.Column<string>(type: "TEXT", nullable: false),
                    KontaktTelefon = table.Column<string>(type: "TEXT", nullable: false),
                    Hemsida = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Brfs_BrfId",
                        column: x => x.BrfId,
                        principalTable: "Brfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Forms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    FormSubmissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentStatus = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_FormSubmissions_FormSubmissionId",
                        column: x => x.FormSubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_BrfId",
                table: "Forms",
                column: "BrfId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserId",
                table: "Forms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmissions_BrfId",
                table: "FormSubmissions",
                column: "BrfId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_FormSubmissionId",
                table: "Purchases",
                column: "FormSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BrfId",
                table: "Users",
                column: "BrfId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RealtorId",
                table: "Users",
                column: "RealtorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "FormSubmissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brfs");

            migrationBuilder.DropTable(
                name: "Realtor");
        }
    }
}
