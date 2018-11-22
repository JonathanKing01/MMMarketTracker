using Microsoft.EntityFrameworkCore.Migrations;

namespace MMMarketTracker.Migrations
{
    public partial class AddUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "MarketSaleRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "MarketSaleRecord");
        }
    }
}
