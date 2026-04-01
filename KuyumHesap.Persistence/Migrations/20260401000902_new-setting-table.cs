using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newsettingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "Description", "IsDeleted", "Key", "ModifyDate", "UpdatedByUserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3560), "Nakit tahsilat/ödeme işlemlerinde kullanılacak kasa hesabının AccountType ID'si", false, "CashAccountTypeId", null, null, null },
                    { 2, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3563), "POS cihazı üzerinden yapılan tahsilat/ödeme hesabının AccountType ID'si", false, "PosAccountTypeId", null, null, null },
                    { 3, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3564), "Banka havalesi/EFT işlemlerinde kullanılacak hesabın AccountType ID'si", false, "BankAccountTypeId", null, null, null },
                    { 4, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3566), "Satış işlemlerinde varsayılan olarak seçilecek para biriminin Currency ID'si", false, "SalesCurrencyId", null, null, null },
                    { 5, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3568), "Satış ekranında tezgahtar seçiminde listelenen hesapların AccountType ID'si", false, "CashierAccountTypeId", null, null, null },
                    { 6, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3569), "Satış ekranında müşteri listesinde gösterilecek hesapların AccountType ID'si", false, "CustomerAccountTypeId", null, null, null },
                    { 7, 1, new DateTime(2026, 4, 1, 3, 9, 0, 878, DateTimeKind.Local).AddTicks(3574), "Satış ekranı açıldığında varsayılan olarak seçili gelecek müşteri Account ID'si", false, "DefaultCustomerAccountId", null, null, null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Key",
                table: "Settings",
                column: "Key",
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

         

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
        }
    }
}
