using Microsoft.EntityFrameworkCore.Migrations;

namespace ntt.data.test.luis.pita.Migrations
{
    public partial class Migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbMovimiento_tbTipoMovimiento_TipoMovimientoId",
                table: "tbMovimiento");

            migrationBuilder.DropTable(
                name: "tbTipoMovimiento");

            migrationBuilder.DropIndex(
                name: "IX_tbMovimiento_TipoMovimientoId",
                table: "tbMovimiento");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoId",
                table: "tbMovimiento");

            migrationBuilder.AddColumn<string>(
                name: "TipoMovimiento",
                table: "tbMovimiento",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMovimiento",
                table: "tbMovimiento");

            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoId",
                table: "tbMovimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbTipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoMovimiento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbMovimiento_TipoMovimientoId",
                table: "tbMovimiento",
                column: "TipoMovimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbMovimiento_tbTipoMovimiento_TipoMovimientoId",
                table: "tbMovimiento",
                column: "TipoMovimientoId",
                principalTable: "tbTipoMovimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
