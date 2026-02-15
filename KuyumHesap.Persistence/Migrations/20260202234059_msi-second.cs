using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class msisecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5717));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "StockGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "StockTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 3, 2, 40, 58, 914, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_AccountId",
                table: "Receipts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
