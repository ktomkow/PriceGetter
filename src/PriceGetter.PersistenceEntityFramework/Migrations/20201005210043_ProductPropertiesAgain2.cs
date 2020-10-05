using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class ProductPropertiesAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPage_ValueAsString",
                table: "Products",
                newName: "ProductPage");

            migrationBuilder.RenameColumn(
                name: "Name_ValueAsString",
                table: "Products",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPage",
                table: "Products",
                newName: "ProductPage_ValueAsString");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Name_ValueAsString");
        }
    }
}
