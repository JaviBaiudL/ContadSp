using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class Nuevabdcompleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    destino = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPedido", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    unidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_usuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monto_aprox = table.Column<double>(type: "double", nullable: false),
                    fecha_ultimo_monto = table.Column<DateOnly>(type: "date", nullable: false),
                    foto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoria_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proceso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    proceso = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monto_minimo = table.Column<double>(type: "double", nullable: false),
                    monto_maximo = table.Column<double>(type: "double", nullable: false),
                    tipo_pedido_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proceso_TipoPedido_tipo_pedido_id",
                        column: x => x.tipo_pedido_id,
                        principalTable: "TipoPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Provision",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha_provision = table.Column<DateOnly>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total = table.Column<double>(type: "double", nullable: false),
                    total_letra = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    destino_id = table.Column<int>(type: "int", nullable: false),
                    proceso_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provision", x => x.id);
                    table.ForeignKey(
                        name: "FK_Provision_Destino_destino_id",
                        column: x => x.destino_id,
                        principalTable: "Destino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provision_Proceso_proceso_id",
                        column: x => x.proceso_id,
                        principalTable: "Proceso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provision_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero_acta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero_proceso = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    provision_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Provision_provision_id",
                        column: x => x.provision_id,
                        principalTable: "Provision",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallePedido",
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
                    estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    articulo_id = table.Column<int>(type: "int", nullable: false),
                    pedido_id = table.Column<int>(type: "int", nullable: false),
                    unidad_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Articulo_articulo_id",
                        column: x => x.articulo_id,
                        principalTable: "Articulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_UnidadMedida_unidad_id",
                        column: x => x.unidad_id,
                        principalTable: "UnidadMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_categoria_id",
                table: "Articulo",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_articulo_id",
                table: "DetallePedido",
                column: "articulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_pedido_id",
                table: "DetallePedido",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_unidad_id",
                table: "DetallePedido",
                column: "unidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_provision_id",
                table: "Pedido",
                column: "provision_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proceso_tipo_pedido_id",
                table: "Proceso",
                column: "tipo_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_destino_id",
                table: "Provision",
                column: "destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_proceso_id",
                table: "Provision",
                column: "proceso_id");

            migrationBuilder.CreateIndex(
                name: "IX_Provision_usuario_id",
                table: "Provision",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Provision");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Proceso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoPedido");
        }
    }
}
