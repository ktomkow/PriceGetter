using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class RenamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPage",
                table: "Products",
                newName: "PageUrl");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Products",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageUrl",
                table: "Products",
                newName: "ProductPage");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ProductImage");
        }
    }
}
