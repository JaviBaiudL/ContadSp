using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSp.Migrations
{
    /// <inheritdoc />
    public partial class Addtabladestinoconsusrespectivasrelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadLetra",
                table: "Modelo_Articulos");

            migrationBuilder.DropColumn(
                name: "CantidadNum",
                table: "Modelo_Articulos");

            migrationBuilder.AddColumn<int>(
                name: "id_destino",
                table: "Modelo_Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modelo_Destino",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    destino = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Destino", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Pedidos_id_destino",
                table: "Modelo_Pedidos",
                column: "id_destino");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelo_Pedidos_Modelo_Destino_id_destino",
                table: "Modelo_Pedidos",
                column: "id_destino",
                principalTable: "Modelo_Destino",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelo_Pedidos_Modelo_Destino_id_destino",
                table: "Modelo_Pedidos");

            migrationBuilder.DropTable(
                name: "Modelo_Destino");

            migrationBuilder.DropIndex(
                name: "IX_Modelo_Pedidos_id_destino",
                table: "Modelo_Pedidos");

            migrationBuilder.DropColumn(
                name: "id_destino",
                table: "Modelo_Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "CantidadLetra",
                table: "Modelo_Articulos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CantidadNum",
                table: "Modelo_Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
