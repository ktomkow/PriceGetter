using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class ProductPropertiesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_ValueAsString",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductPage_ValueAsString",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_ValueAsString",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPage_ValueAsString",
                table: "Products");
        }
    }
}
