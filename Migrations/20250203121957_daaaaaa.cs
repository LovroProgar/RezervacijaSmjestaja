using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class daaaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 12,
                column: "SlikaUrl",
                value: "https://images.pexels.com/photos/1571460/pexels-photo-1571460.jpeg?w=1280");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Smjestaji",
                keyColumn: "Id",
                keyValue: 12,
                column: "SlikaUrl",
                value: "https://images.pexels.com/photos/1643386/pexels-photo-1643386.jpeg?w=1280");
        }
    }
}
