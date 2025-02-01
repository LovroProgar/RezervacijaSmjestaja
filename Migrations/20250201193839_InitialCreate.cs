using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Smjestaji",
                columns: new[] { "Id", "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[,]
                {
                    { 1, 120m, "Hotel Blue Lagoon", "Luksuzan hotel uz obalu", "https://source.unsplash.com/400x300/?hotel" },
                    { 2, 250m, "Villa Sun", "Privatna vila s bazenom", "https://source.unsplash.com/400x300/?villa" },
                    { 3, 180m, "Mountain Resort", "Odmaralište u planinama", "https://source.unsplash.com/400x300/?resort" },
                    { 4, 100m, "Apartman Deluxe", "Moderan apartman u centru", "https://source.unsplash.com/400x300/?apartment" },
                    { 5, 80m, "Seoska Kuća", "Mirno mjesto za odmor", "https://source.unsplash.com/400x300/?cottage" },
                    { 6, 200m, "Beach House", "Kuća na plaži s pogledom", "https://source.unsplash.com/400x300/?beach" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
