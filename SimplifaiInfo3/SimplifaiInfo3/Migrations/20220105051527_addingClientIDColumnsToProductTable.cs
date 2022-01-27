using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplifaiInfo3.Migrations
{
    public partial class addingClientIDColumnsToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientId",
                table: "ProductTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clientId",
                table: "ProductTable");
        }
    }
}
