using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class agregocamposyrelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numero_proceso",
                table: "Pedido",
                newName: "proceso_pedido_id");

            migrationBuilder.AddColumn<string>(
                name: "sigla",
                table: "Proceso",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Pedido",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProcesoPedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_proceso = table.Column<int>(type: "int", nullable: false),
                    proceso_completo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proceso_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesoPedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcesoPedido_Proceso_proceso_id",
                        column: x => x.proceso_id,
                        principalTable: "Proceso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_proceso_pedido_id",
                table: "Pedido",
                column: "proceso_pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesoPedido_proceso_id",
                table: "ProcesoPedido",
                column: "proceso_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ProcesoPedido_proceso_pedido_id",
                table: "Pedido",
                column: "proceso_pedido_id",
                principalTable: "ProcesoPedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ProcesoPedido_proceso_pedido_id",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "ProcesoPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_proceso_pedido_id",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "sigla",
                table: "Proceso");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "proceso_pedido_id",
                table: "Pedido",
                newName: "numero_proceso");
        }
    }
}
