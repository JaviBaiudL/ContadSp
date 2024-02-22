using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSp.Migrations
{
    /// <inheritdoc />
    public partial class Addtablapedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Modelo_Pedidoid",
                table: "Modelo_Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Modelo_Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    destino = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usuario_solicita = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Pedidos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Articulos_Modelo_Pedidoid",
                table: "Modelo_Articulos",
                column: "Modelo_Pedidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelo_Articulos_Modelo_Pedidos_Modelo_Pedidoid",
                table: "Modelo_Articulos",
                column: "Modelo_Pedidoid",
                principalTable: "Modelo_Pedidos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelo_Articulos_Modelo_Pedidos_Modelo_Pedidoid",
                table: "Modelo_Articulos");

            migrationBuilder.DropTable(
                name: "Modelo_Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Modelo_Articulos_Modelo_Pedidoid",
                table: "Modelo_Articulos");

            migrationBuilder.DropColumn(
                name: "Modelo_Pedidoid",
                table: "Modelo_Articulos");
        }
    }
}
