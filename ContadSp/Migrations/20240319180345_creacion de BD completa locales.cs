using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSp.Migrations
{
    /// <inheritdoc />
    public partial class creaciondeBDcompletalocales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelo_ABM_Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_ABM_Categoria", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "Modelo_Articulos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monto_aprox = table.Column<double>(type: "double", nullable: false),
                    fecha_ultimo_monto = table.Column<DateOnly>(type: "date", nullable: false),
                    foto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Articulos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Modelo_Articulos_Modelo_ABM_Categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "Modelo_ABM_Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelo_Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usuario_solicita = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total = table.Column<double>(type: "double", nullable: false),
                    total_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Modelo_Pedidos_Modelo_Destino_id_destino",
                        column: x => x.id_destino,
                        principalTable: "Modelo_Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modelo_Detalle_Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    precio = table.Column<double>(type: "double", nullable: false),
                    precio_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<double>(type: "double", nullable: false),
                    subtotal_letra = table.Column<string>(type: "longtext", nullable: true)
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
                name: "IX_Modelo_Articulos_id_categoria",
                table: "Modelo_Articulos",
                column: "id_categoria");

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

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Pedidos_id_destino",
                table: "Modelo_Pedidos",
                column: "id_destino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelo_Detalle_Pedido");

            migrationBuilder.DropTable(
                name: "Modelo_Articulos");

            migrationBuilder.DropTable(
                name: "Modelo_Pedidos");

            migrationBuilder.DropTable(
                name: "Modelo_Unidad_Medida");

            migrationBuilder.DropTable(
                name: "Modelo_ABM_Categoria");

            migrationBuilder.DropTable(
                name: "Modelo_Destino");
        }
    }
}
