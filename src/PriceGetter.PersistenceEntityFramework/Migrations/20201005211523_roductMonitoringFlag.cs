using Microsoft.EntityFrameworkCore.Migrations;

namespace PriceGetter.PersistenceEntityFramework.Migrations
{
    public partial class roductMonitoringFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MonitoringActive",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonitoringActive",
                table: "Products");
        }
    }
}
