using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class _122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "/pictures/1.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2,
                column: "SlikaUrl",
                value: "/pictures/2.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3,
                column: "SlikaUrl",
                value: "/pictures/3.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4,
                column: "SlikaUrl",
                value: "/pictures/4.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                column: "SlikaUrl",
                value: "/pictures/5.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                column: "SlikaUrl",
                value: "/pictures/6.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://www.cimerfraj.hr/slike/zajednica/fotografije-koje-prodaju-smjestaj-anja-sibenik-2.jpg");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 2,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?villa");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 3,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?resort");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 4,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?apartment");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 5,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?cottage");

            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 6,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?beach");
        }
    }
}
