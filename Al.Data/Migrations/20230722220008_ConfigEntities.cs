using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Al.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorId", "ColorName" },
                values: new object[,]
                {
                    { 1, "قرمز" },
                    { 2, "آبی" },
                    { 3, "مشکی" },
                    { 4, "بنفش" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Iran" },
                    { 2, "Israel" },
                    { 3, "China" },
                    { 4, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Factories",
                columns: new[] { "FactoryId", "FactoryName" },
                values: new object[,]
                {
                    { 1, "ChiTX" },
                    { 2, "SinaX" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName", "ParentId" },
                values: new object[,]
                {
                    { 4, "آره برقی", 1 },
                    { 5, "ماشین چمن زن", 2 },
                    { 6, "پمپ آب", 3 }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "YearId", "ProductionYear" },
                values: new object[,]
                {
                    { 1, 2019 },
                    { 2, 2020 },
                    { 3, 2021 },
                    { 4, 2022 },
                    { 5, 2023 },
                    { 6, 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "FactoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Factories",
                keyColumn: "FactoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "YearId",
                keyValue: 6);
        }
    }
}
