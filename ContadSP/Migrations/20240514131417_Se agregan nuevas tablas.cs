using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class Seagregannuevastablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provision_Proceso_proceso_id",
                table: "Provision");

            migrationBuilder.DropIndex(
                name: "IX_Provision_proceso_id",
                table: "Provision");

            migrationBuilder.DropColumn(
                name: "proceso_id",
                table: "Provision");

            migrationBuilder.CreateTable(
                name: "DetalleProvision",
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
                    unidad_id = table.Column<int>(type: "int", nullable: false),
                    proceso_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProvision", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_Articulo_articulo_id",
                        column: x => x.articulo_id,
                        principalTable: "Articulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_Proceso_proceso_id",
                        column: x => x.proceso_id,
                        principalTable: "Proceso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProvision_UnidadMedida_unidad_id",
                        column: x => x.unidad_id,
                        principalTable: "UnidadMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SitFiscal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sit_fiscal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitFiscal", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre_comercial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sit_fiscal_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proveedor_SitFiscal_sit_fiscal_id",
                        column: x => x.sit_fiscal_id,
                        principalTable: "SitFiscal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_articulo_id",
                table: "DetalleProvision",
                column: "articulo_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_proceso_id",
                table: "DetalleProvision",
                column: "proceso_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_unidad_id",
                table: "DetalleProvision",
                column: "unidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_sit_fiscal_id",
                table: "Proveedor",
                column: "sit_fiscal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProvision");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "SitFiscal");

            migrationBuilder.AddColumn<int>(
                name: "proceso_id",
                table: "Provision",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Provision_proceso_id",
                table: "Provision",
                column: "proceso_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provision_Proceso_proceso_id",
                table: "Provision",
                column: "proceso_id",
                principalTable: "Proceso",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
