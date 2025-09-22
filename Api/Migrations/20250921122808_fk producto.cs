using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class fkproducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductoId",
                table: "Talle",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductoId",
                table: "Color",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talle_ProductoId",
                table: "Talle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductoId",
                table: "Color",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Producto_ProductoId",
                table: "Color",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Talle_Producto_ProductoId",
                table: "Talle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Producto_ProductoId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Talle_Producto_ProductoId",
                table: "Talle");

            migrationBuilder.DropIndex(
                name: "IX_Talle_ProductoId",
                table: "Talle");

            migrationBuilder.DropIndex(
                name: "IX_Color_ProductoId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Talle");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Color");
        }
    }
}
