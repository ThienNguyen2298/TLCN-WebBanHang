using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMartWebsite.Migrations
{
    public partial class confirmfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "confirm",
                table: "order",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "product");

            migrationBuilder.DropColumn(
                name: "confirm",
                table: "order");
        }
    }
}
