using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSp.Migrations
{
    /// <inheritdoc />
    public partial class basecompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelo_Articulos_Modelo_Pedidos_Modelo_Pedidoid",
                table: "Modelo_Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Modelo_Articulos_Modelo_Pedidoid",
                table: "Modelo_Articulos");

            migrationBuilder.DropColumn(
                name: "Modelo_Pedidoid",
                table: "Modelo_Articulos");

            migrationBuilder.AddColumn<string>(
                name: "foto",
                table: "Modelo_Articulos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelo_Unidad_Medida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    unidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Unidad_Medida", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelo_Detalle_Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    cantidad_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_articulo = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_unidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Detalle_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Modelo_Detalle_Pedido_Modelo_Articulos_id_articulo",
                        column: x => x.id_articulo,
                        principalTable: "Modelo_Articulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelo_Detalle_Pedido_Modelo_Pedidos_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Modelo_Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelo_Detalle_Pedido_Modelo_Unidad_Medida_id_unidad",
                        column: x => x.id_unidad,
                        principalTable: "Modelo_Unidad_Medida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Detalle_Pedido_id_articulo",
                table: "Modelo_Detalle_Pedido",
                column: "id_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Detalle_Pedido_id_pedido",
                table: "Modelo_Detalle_Pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Detalle_Pedido_id_unidad",
                table: "Modelo_Detalle_Pedido",
                column: "id_unidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelo_Detalle_Pedido");

            migrationBuilder.DropTable(
                name: "Modelo_Unidad_Medida");

            migrationBuilder.DropColumn(
                name: "foto",
                table: "Modelo_Articulos");

            migrationBuilder.AddColumn<int>(
                name: "Modelo_Pedidoid",
                table: "Modelo_Articulos",
                type: "int",
                nullable: true);

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
    }
}
