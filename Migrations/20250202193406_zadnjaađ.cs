using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class zadnjaađ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Smjestaji",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grad",
                value: "Zagreb");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2,
                column: "Grad",
                value: "Split");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grad",
                value: "Rijeka");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4,
                column: "Grad",
                value: "Osijek");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                column: "Grad",
                value: "Dubrovnik");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                column: "Grad",
                value: "Zadar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Smjestaji");
        }
    }
}
