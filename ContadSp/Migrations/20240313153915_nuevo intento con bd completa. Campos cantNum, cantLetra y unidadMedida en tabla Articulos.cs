using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContadSp.Migrations
{
    /// <inheritdoc />
    public partial class nuevointentoconbdcompletaCamposcantNumcantLetrayunidadMedidaentablaArticulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CantidadNum",
                table: "Modelo_Articulos",
                newName: "cantidadNum");

            migrationBuilder.RenameColumn(
                name: "CantidadLetra",
                table: "Modelo_Articulos",
                newName: "cantidadLetra");

            migrationBuilder.AlterColumn<string>(
                name: "cantidadLetra",
                table: "Modelo_Articulos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cantidadNum",
                table: "Modelo_Articulos",
                newName: "CantidadNum");

            migrationBuilder.RenameColumn(
                name: "cantidadLetra",
                table: "Modelo_Articulos",
                newName: "CantidadLetra");

            migrationBuilder.UpdateData(
                table: "Modelo_Articulos",
                keyColumn: "CantidadLetra",
                keyValue: null,
                column: "CantidadLetra",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CantidadLetra",
                table: "Modelo_Articulos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
