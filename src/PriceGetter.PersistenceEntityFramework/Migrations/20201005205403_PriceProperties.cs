using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class PriceProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "At",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "At",
                table: "Prices");
        }
    }
}
