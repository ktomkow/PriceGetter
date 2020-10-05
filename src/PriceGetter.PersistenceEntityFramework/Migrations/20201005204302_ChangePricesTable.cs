using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class ChangePricesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Products_ProductId",
                table: "Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "Price",
                newName: "Prices");

            migrationBuilder.RenameIndex(
                name: "IX_Price_ProductId",
                table: "Prices",
                newName: "IX_Prices_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Products_ProductId",
                table: "Prices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Products_ProductId",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_ProductId",
                table: "Price",
                newName: "IX_Price_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Products_ProductId",
                table: "Price",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
