using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class cambiosenbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "DetalleProvision");

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Provision",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "provision_id",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_provision_id",
                table: "Pedido",
                column: "provision_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Provision_provision_id",
                table: "Pedido",
                column: "provision_id",
                principalTable: "Provision",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Provision_provision_id",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_provision_id",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Provision");

            migrationBuilder.DropColumn(
                name: "provision_id",
                table: "Pedido");

            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "DetalleProvision",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
