using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ntt.data.test.luis.pita.Migrations
{
    public partial class Migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbTipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoMovimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimientoId = table.Column<int>(type: "int", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbMovimiento_tbCuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "tbCuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbMovimiento_tbTipoMovimiento_TipoMovimientoId",
                        column: x => x.TipoMovimientoId,
                        principalTable: "tbTipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbMovimiento_CuentaId",
                table: "tbMovimiento",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMovimiento_TipoMovimientoId",
                table: "tbMovimiento",
                column: "TipoMovimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbMovimiento");

            migrationBuilder.DropTable(
                name: "tbTipoMovimiento");
        }
    }
}
