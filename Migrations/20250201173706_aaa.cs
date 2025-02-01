using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { "Hotel Blue Lagoon", "Luksuzan hotel uz obalu", "https://source.unsplash.com/400x300/?hotel" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 250m, "Villa Sun", "Privatna vila s bazenom", "https://source.unsplash.com/400x300/?villa" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 180m, "Mountain Resort", "Odmaralište u planinama", "https://source.unsplash.com/400x300/?resort" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 100m, "Apartman Deluxe", "Moderan apartman u centru", "https://source.unsplash.com/400x300/?apartment" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 80m, "Seoska Kuća", "Mirno mjesto za odmor", "https://source.unsplash.com/400x300/?cottage" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 200m, "Beach House", "Kuća na plaži s pogledom", "https://source.unsplash.com/400x300/?beach" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { "Vila Aurora", "Split, Hrvatska", "https://via.placeholder.com/400x200.png?text=Vila+Aurora" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 150.00m, "Apartmani Sunce", "Dubrovnik, Hrvatska", "https://via.placeholder.com/400x200.png?text=Apartmani+Sunce" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 100.00m, "Bungalovi More", "Zadar, Hrvatska", "https://via.placeholder.com/400x200.png?text=Bungalovi+More" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 200.00m, "Hotel Lav", "Rijeka, Hrvatska", "https://via.placeholder.com/400x200.png?text=Hotel+Lav" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 180.00m, "Vila Mediteran", "Šibenik, Hrvatska", "https://via.placeholder.com/400x200.png?text=Vila+Mediteran" });

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CijenaPoNoci", "Naziv", "Opis", "SlikaUrl" },
                values: new object[] { 90.00m, "Apartmani Mir", "Pula, Hrvatska", "https://via.placeholder.com/400x200.png?text=Apartmani+Mir" });
        }
    }
}
