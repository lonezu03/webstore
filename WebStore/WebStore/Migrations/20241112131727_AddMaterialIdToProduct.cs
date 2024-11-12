using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialIdToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Gender_GenderId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Material_MaterialId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_GenderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MaterialId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Gender_Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Material_Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Gender_Id",
                table: "Product",
                column: "Gender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Material_Id",
                table: "Product",
                column: "Material_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Gender_Gender_Id",
                table: "Product",
                column: "Gender_Id",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Material_Material_Id",
                table: "Product",
                column: "Material_Id",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Gender_Gender_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Material_Material_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Gender_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Material_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Gender_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Material_Id",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_GenderId",
                table: "Product",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MaterialId",
                table: "Product",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Gender_GenderId",
                table: "Product",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Material_MaterialId",
                table: "Product",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id");
        }
    }
}
