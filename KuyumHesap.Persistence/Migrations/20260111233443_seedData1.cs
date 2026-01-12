using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "BuyRate", "Country", "CreatedByUserId", "CreatedDate", "CurrencyCode", "CurrencyName", "IsActive", "IsBaseCurrency", "IsDeleted", "IsNationalCurrency", "MetaCode", "ModifyDate", "SellRate", "Symbol", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 0.995m, "GLOBAL", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6499), "HAS", "ALTIN 1000", true, true, false, false, "ALTIN", null, 1.005m, "HAS", null },
                    { 2, 0.99m, "AMERİKA BİRLEŞİK DEVLETLERİ", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6530), "USD", "AMERİKAN DOLARI", true, false, false, false, "USDTRY", null, 1.01m, "$", null },
                    { 3, 1m, "TÜRKİYE", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6538), "TRY", "TÜRK LİRASI", true, false, false, true, "", null, 1m, "₺", null },
                    { 4, 0.99m, "AVRUPA BİRLİĞİ", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6545), "EUR", "AVRUPA PARA BİRİMİ", true, false, false, false, "EURTRY", null, 1.01m, "€", null },
                    { 5, 0.99m, "İSVİÇRE", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6552), "CHF", "İSVİÇRE FRANGI", true, false, false, false, "CHFTRY", null, 1.01m, "CHF", null },
                    { 6, 1m, "AMERİKA BİRLEŞİK DEVLETLERİ", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6558), "SAR", "SUUDİ ARABİSTAN RİYALİ", true, false, false, false, "SARTRY", null, 1m, "SAR", null },
                    { 7, 0.99m, "AMERİKA BİRLEŞİK DEVLETLERİ", 1, new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(6565), "GHS", "GÜMÜŞ HASI", true, false, false, false, "GUMUSTRY", null, 1.01m, "GHS", null }
                });

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 985, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.InsertData(
                table: "StockTypes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "CurrencyId", "IsActive", "IsDeleted", "ModifyDate", "StockGroupId", "StockTypeName", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2719), 7, true, false, null, 2, "GÜMÜŞ", null },
                    { 4, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2722), 7, true, false, null, 3, "HURDA GÜMÜŞ", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.InsertData(
                table: "StockTypes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "CurrencyId", "IsActive", "IsDeleted", "ModifyDate", "StockGroupId", "StockTypeName", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2715), 1, true, false, null, 2, "ALTIN", null },
                    { 3, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2721), 1, true, false, null, 3, "HURDA ALTIN", null },
                    { 5, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2723), 2, true, false, null, 1, "PIRLANTA", null },
                    { 6, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2724), 3, true, false, null, 1, "SAAT", null },
                    { 7, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2725), 2, true, false, null, 1, "ELMAS", null },
                    { 8, 1, new DateTime(2026, 1, 12, 2, 34, 41, 986, DateTimeKind.Local).AddTicks(2726), 1, true, false, null, 2, "SARRAFİYE", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 868, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3699));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 1, 9, 15, 42, 28, 869, DateTimeKind.Local).AddTicks(5095));
        }
    }
}
