using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class millrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "MillRate",
                table: "Stocks",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 372, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "Description", "IsDeleted", "Key", "ModifyDate", "UpdatedByUserId", "Value" },
                values: new object[,]
                {
                    { 8, 1, new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(8002), "Nakit tahsilat/ödeme işlemlerinde varsayılan kasa hesabı", false, "DefaultCashAccountId", null, null, null },
                    { 9, 1, new DateTime(2026, 4, 10, 0, 52, 29, 373, DateTimeKind.Local).AddTicks(8003), "İskonto işlemlerinde borçlandırılacak hesap", false, "DefaultDiscountAccountId", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 10, 0, 52, 29, 374, DateTimeKind.Local).AddTicks(3336));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "MillRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountName", "AccountTypeId", "City", "Country", "CreatedByUserId", "CreatedDate", "CustomerType", "District", "Email", "FullAddress", "GeneralInformation", "ImagePath", "IsActive", "IsCashier", "IsDeleted", "MobilePhone", "ModifyDate", "NationalIdNumber", "Neighborhood", "TaxNumber", "TaxOffice", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "KASA", 7, null, null, 1, new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(5822), "Sistem", null, null, null, null, null, false, false, false, null, null, null, null, null, null, null },
                    { 2, "PEŞİN MÜŞTERİ", 2, null, null, 1, new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(5827), "Sistem", null, null, null, null, null, false, false, false, null, null, null, null, null, null, null },
                    { 3, "İSKONTO SATIŞTAN", 9, null, null, 1, new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(5829), "Sistem", null, null, null, null, null, false, false, false, null, null, null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 877, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(6616));
        }
    }
}
