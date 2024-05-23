using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class columnaprovision_idqueeslarelacionentredetalleProvisionyProvision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Provision_provision_id",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_provision_id",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "provision_id",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "provision_id",
                table: "DetalleProvision",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_provision_id",
                table: "DetalleProvision",
                column: "provision_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProvision_Provision_provision_id",
                table: "DetalleProvision",
                column: "provision_id",
                principalTable: "Provision",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProvision_Provision_provision_id",
                table: "DetalleProvision");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProvision_provision_id",
                table: "DetalleProvision");

            migrationBuilder.DropColumn(
                name: "provision_id",
                table: "DetalleProvision");

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
    }
}
