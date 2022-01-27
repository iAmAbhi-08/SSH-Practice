using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplifaiInfo3.Migrations
{
    public partial class addTablesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTable",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTable", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "ClientsTable",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priceOfPurchase = table.Column<double>(type: "float", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsTable", x => x.clientId);
                    table.ForeignKey(
                        name: "FK_ClientsTable_ProductTable_productId",
                        column: x => x.productId,
                        principalTable: "ProductTable",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsTable_productId",
                table: "ClientsTable",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsTable");

            migrationBuilder.DropTable(
                name: "ProductTable");
        }
    }
}
