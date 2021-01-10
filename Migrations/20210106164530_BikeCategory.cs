using Microsoft.EntityFrameworkCore.Migrations;

namespace Butuza_Elena_Proiect.Migrations
{
    public partial class BikeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Bike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BikeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BikeCategory_Bike_BikeID",
                        column: x => x.BikeID,
                        principalTable: "Bike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_StoreID",
                table: "Bike",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeCategory_BikeID",
                table: "BikeCategory",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeCategory_CategoryID",
                table: "BikeCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_Store_StoreID",
                table: "Bike",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_Store_StoreID",
                table: "Bike");

            migrationBuilder.DropTable(
                name: "BikeCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Bike_StoreID",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Bike");
        }
    }
}
