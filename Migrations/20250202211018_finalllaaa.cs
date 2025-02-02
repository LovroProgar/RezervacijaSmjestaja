using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class finalllaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smjestaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SlikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CijenaPoNoci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjestaji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmjestajId = table.Column<int>(type: "int", nullable: false),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Smjestaji_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Smjestaji",
                columns: new[] { "Id", "CijenaPoNoci", "Grad", "Naziv", "Opis", "SlikaUrl" },
                values: new object[,]
                {
                    { 1, 120m, "Zagreb", "Modern City Apartment", "Luksuzan apartman u centru grada", "https://images.pexels.com/photos/439391/pexels-photo-439391.jpeg?w=1280" },
                    { 2, 250m, "Split", "Seaside Apartment", "Apartman s pogledom na more", "https://images.pexels.com/photos/439416/pexels-photo-439416.jpeg?w=1280" },
                    { 3, 180m, "Rijeka", "Cozy Mountain Loft", "Moderan loft u planinama", "https://images.pexels.com/photos/276651/pexels-photo-276651.jpeg?w=1280" },
                    { 4, 300m, "Osijek", "Luxury Penthouse", "Ekskluzivan penthouse s terasom", "https://images.pexels.com/photos/707581/pexels-photo-707581.jpeg?w=1280" },
                    { 5, 100m, "Dubrovnik", "Rustic Countryside Home", "Udobna kuća u prirodi", "https://images.pexels.com/photos/279746/pexels-photo-279746.jpeg?w=1280" },
                    { 6, 200m, "Pula", "Tropical Beach Apartment", "Apartman uz samu plažu", "https://images.pexels.com/photos/271618/pexels-photo-271618.jpeg?w=1280" },
                    { 7, 160m, "Zadar", "Elegant City Suite", "Moderan apartman s elegantnim dizajnom", "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?w=1280" },
                    { 8, 220m, "Šibenik", "Hillside Retreat", "Apartman na osami s predivnim pogledom", "https://images.pexels.com/photos/2029738/pexels-photo-2029738.jpeg?w=1280" },
                    { 9, 140m, "Varaždin", "Panoramic View Apartment", "Apartman s panoramskim pogledom", "https://images.pexels.com/photos/2089698/pexels-photo-2089698.jpeg?w=1280" },
                    { 10, 320m, "Karlovac", "Seaview Penthouse", "Penthouse s pogledom na more", "https://images.pexels.com/photos/1438834/pexels-photo-1438834.jpeg?w=1280" },
                    { 11, 110m, "Makarska", "Downtown Studio", "Minimalistički studio u centru", "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280" },
                    { 12, 130m, "Hvar", "Wooden Chalet", "Planinska brvnara za potpuni odmor", "https://images.pexels.com/photos/271618/pexels-photo-271618.jpeg?w=1280" },
                    { 13, 400m, "Zadar", "Luxury Villa", "Privatna vila s bazenom", "https://images.pexels.com/photos/276554/pexels-photo-276554.jpeg?w=1280" },
                    { 14, 175m, "Šibenik", "Modern Apartment", "Stilno uređen apartman u centru", "https://images.pexels.com/photos/439416/pexels-photo-439416.jpeg?w=1280" },
                    { 15, 145m, "Plitvice", "Open Space Loft", "Prostrani loft s modernim dizajnom", "https://images.pexels.com/photos/439391/pexels-photo-439391.jpeg?w=1280" },
                    { 16, 135m, "Dubrovnik", "City Center Apartment", "Savršeno mjesto za urbane nomade", "https://images.pexels.com/photos/276671/pexels-photo-276671.jpeg?w=1280" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_SmjestajId",
                table: "Rezervacije",
                column: "SmjestajId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Smjestaji");
        }
    }
}
