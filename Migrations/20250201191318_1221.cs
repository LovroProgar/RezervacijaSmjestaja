using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class _1221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                column: "Naziv",
                value: "Apartman Val");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                column: "Naziv",
                value: "Villa Sopranos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                column: "Naziv",
                value: "Seoska Kuća");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                column: "Naziv",
                value: "Beach House");
        }
    }
}
