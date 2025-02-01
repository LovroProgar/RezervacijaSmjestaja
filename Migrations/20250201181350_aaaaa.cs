using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class aaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://www.cimerfraj.hr/slike/zajednica/fotografije-koje-prodaju-smjestaj-anja-sibenik-2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 1,
                column: "SlikaUrl",
                value: "https://source.unsplash.com/400x300/?hotel");
        }
    }
}
