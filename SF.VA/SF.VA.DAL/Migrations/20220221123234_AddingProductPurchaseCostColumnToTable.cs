using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.VA.DAL.Migrations
{
    public partial class AddingProductPurchaseCostColumnToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProductPurchaseCost",
                table: "ProductTable",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPurchaseCost",
                table: "ProductTable");
        }
    }
}
