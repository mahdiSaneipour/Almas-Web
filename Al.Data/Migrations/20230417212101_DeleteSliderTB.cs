using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Al.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSliderTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSliders");

            migrationBuilder.AddColumn<bool>(
                name: "IsSlide",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSlide",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductSliders",
                columns: table => new
                {
                    ProductSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSliders", x => x.ProductSliderId);
                    table.ForeignKey(
                        name: "FK_ProductSliders_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSliders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSliders_GroupId",
                table: "ProductSliders",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSliders_ProductId",
                table: "ProductSliders",
                column: "ProductId",
                unique: true);
        }
    }
}
