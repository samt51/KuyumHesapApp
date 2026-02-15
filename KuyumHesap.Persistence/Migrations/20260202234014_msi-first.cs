using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class msifirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CurrentAccountId",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Receipts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 13, 891, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentAccountId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 2, 19, 9, 8, 737, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
