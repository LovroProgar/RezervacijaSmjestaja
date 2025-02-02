using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class zadnji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Korisnici_KorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Smjestaj_SmjestajId",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Smjestaj",
                table: "Smjestaj");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Rezervacije");

            migrationBuilder.RenameTable(
                name: "Smjestaj",
                newName: "Smjestaji");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Smjestaji",
                table: "Smjestaji",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Smjestaji_SmjestajId",
                table: "Rezervacije",
                column: "SmjestajId",
                principalTable: "Smjestaji",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Smjestaji_SmjestajId",
                table: "Rezervacije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Smjestaji",
                table: "Smjestaji");

            migrationBuilder.RenameTable(
                name: "Smjestaji",
                newName: "Smjestaj");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Smjestaj",
                table: "Smjestaj",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Korisnici_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Smjestaj_SmjestajId",
                table: "Rezervacije",
                column: "SmjestajId",
                principalTable: "Smjestaj",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
