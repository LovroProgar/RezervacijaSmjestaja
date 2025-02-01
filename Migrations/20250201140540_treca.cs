﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijaSmjestaja.Migrations
{
    /// <inheritdoc />
    public partial class treca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smjestaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CijenaPoNoci = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    SmjestajId = table.Column<int>(type: "int", nullable: false),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Smjestaji_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_SmjestajId",
                table: "Rezervacije",
                column: "SmjestajId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Smjestaji");
        }
    }
}
