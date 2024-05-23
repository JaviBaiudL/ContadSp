using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSP.Migrations
{
    /// <inheritdoc />
    public partial class nuevoscambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProvision_Proceso_proceso_id",
                table: "DetalleProvision");

            migrationBuilder.DropIndex(
                name: "IX_DetalleProvision_proceso_id",
                table: "DetalleProvision");

            migrationBuilder.DropColumn(
                name: "proceso_id",
                table: "DetalleProvision");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "proceso_id",
                table: "DetalleProvision",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProvision_proceso_id",
                table: "DetalleProvision",
                column: "proceso_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProvision_Proceso_proceso_id",
                table: "DetalleProvision",
                column: "proceso_id",
                principalTable: "Proceso",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
