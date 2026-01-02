using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initiliazer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BalanceOrder = table.Column<int>(type: "int", nullable: false),
                    IsSubBalanceCalculated = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRfid = table.Column<bool>(type: "bit", nullable: false),
                    StartWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBaseCurrency = table.Column<bool>(type: "bit", nullable: false),
                    IsNationalCurrency = table.Column<bool>(type: "bit", nullable: false),
                    MetaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRateTickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRateTickers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GC = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SC = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoGeneratedTransactionTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCashier = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeHeaderId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    IsBold = table.Column<bool>(type: "bit", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarcodeDetails_BarcodeHeaders_BarcodeHeaderId",
                        column: x => x.BarcodeHeaderId,
                        principalTable: "BarcodeHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeRateId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    BuyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousCloseRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BagliHesapID = table.Column<int>(type: "int", nullable: true),
                    BarkodYaziciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FisYaziciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VarsayilanYaziciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockGroupId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTypes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTypes_StockGroups_StockGroupId",
                        column: x => x.StockGroupId,
                        principalTable: "StockGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentAccountId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCustomerReceipt = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenBalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_AssignedByUserId",
                        column: x => x.AssignedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StockGroupId = table.Column<int>(type: "int", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockUnitId = table.Column<int>(type: "int", nullable: false),
                    LaborUnitId = table.Column<int>(type: "int", nullable: false),
                    MillRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_StockGroups_StockGroupId",
                        column: x => x.StockGroupId,
                        principalTable: "StockGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_StockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignCurrencyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignCurrencyId = table.Column<int>(type: "int", nullable: true),
                    ForeignExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CounterCurrencyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CounterCurrencyId = table.Column<int>(type: "int", nullable: true),
                    CounterExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BaseCurrencyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProfitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CounterTransactionId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MillRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborQuantity = table.Column<int>(type: "int", nullable: true),
                    IsLaborIncluded = table.Column<bool>(type: "bit", nullable: true),
                    IsReconciled = table.Column<bool>(type: "bit", nullable: true),
                    NetProductValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalLaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movements_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movements_MovementTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "MovementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movements_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movements_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "AccountTypeName", "BalanceOrder", "CreatedByUserId", "CreatedDate", "IsActive", "IsDeleted", "IsSubBalanceCalculated", "ModifyDate", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "SERMAYELER", 100, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5078), true, false, true, null, null },
                    { 2, "MÜŞTERİLER", 1, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5082), true, false, false, null, null },
                    { 3, "TOPTANCILAR", 2, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5083), true, false, false, null, null },
                    { 4, "ATÖLYELER", 3, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5084), true, false, false, null, null },
                    { 5, "BANKALAR", 4, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5085), true, false, false, null, null },
                    { 6, "POSLAR", 5, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5086), true, false, false, null, null },
                    { 7, "KASALAR", 6, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5087), true, false, false, null, null },
                    { 8, "GİDER/GELİR", 7, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5089), true, false, true, null, null },
                    { 9, "İSKONTOLAR", 8, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5090), true, false, true, null, null },
                    { 10, "KAR/ZARAR", 9, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5091), true, false, true, null, null },
                    { 11, "DEMİRBAŞLAR", 10, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5092), true, false, false, null, null },
                    { 12, "ÖZELHESAPLAR", 11, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5093), true, false, false, null, null },
                    { 13, "PERSONEL", 12, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5094), true, false, false, null, null },
                    { 14, "STOKLAR", 13, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(5095), true, false, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "MovementTypes",
                columns: new[] { "Id", "AutoGeneratedTransactionTypeId", "CreatedByUserId", "CreatedDate", "Description", "GC", "IsActive", "IsDeleted", "ModifyDate", "SC", "TransactionCode", "TransactionName", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6500), "NAKİT GİRİŞ İŞLEMLERİ İÇİN KULLANILIR", "G", true, false, null, "C", "NG", "NAKİT GİRİŞ", null },
                    { 2, 1, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6508), "NAKİT ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR", "C", true, false, null, "G", "NC", "NAKİT ÇIKIŞ", null },
                    { 3, 4, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6510), "ÜRÜN GİRİŞ İŞLEMLERİ İÇİN KULLANILIR", "G", true, false, null, "C", "UG", "ÜRÜN GİRİŞ", null },
                    { 4, 3, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6512), "ÜRÜN ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR", "C", true, false, null, "C", "UC", "ÜRÜN ÇIKIŞ", null },
                    { 5, 6, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6513), "HESABIN ALACAĞINA İSKONTO YAZMAK İÇİN", "G", true, false, null, "C", "ALC", "ISKONTO ALACAKLANDIR", null },
                    { 6, 5, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6515), "HESABIN BORCUNA İSKONTO YAZMAK İÇİN", "C", true, false, null, "C", "BRC", "ISKONTO BORCLANDIR", null },
                    { 7, 8, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6516), "VİRMAN(HAVALE) GİRİŞ İŞLEMLERİ İÇİN KULLANILIR", "G", true, false, null, "C", "VRG", "VİRMAN GİRİŞ", null },
                    { 8, 7, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6518), "VİRMAN(HAVALE) ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR", "C", true, false, null, "C", "VRC", "VİRMAN ÇIKIŞ", null },
                    { 9, 10, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6520), "ÇEVİRME GİRİŞ İŞLEMLERİ İÇİN KULLANILIR", "G", true, false, null, "C", "CVG", "ÇEVİRME GİRİŞ", null },
                    { 10, 9, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(6521), "ÇEVİRME ÇIKIŞ İŞLEMLERİ İÇİN KULLANILIR", "C", true, false, null, "C", "CVC", "ÇEVİRME ÇIKIŞ", null }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "IsDeleted", "ModifyDate", "ProductTypeName", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(7432), false, null, "YÜZÜK", null },
                    { 2, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(7435), false, null, "KÜPE", null },
                    { 3, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(7436), false, null, "ALYANS", null },
                    { 4, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(7437), false, null, "BİLEKLİK", null },
                    { 5, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(7437), false, null, "KELEPÇE", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedByUserId", "CreatedDate", "IsDeleted", "ModifyDate", "Name", "Type", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "ADMIN", 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(8298), false, null, "Admin", "System", null },
                    { 2, "USER", 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(8302), false, null, "User", "System", null }
                });

            migrationBuilder.InsertData(
                table: "StockGroups",
                columns: new[] { "Id", "CreatedByUserId", "CreatedDate", "IsDeleted", "ModifyDate", "StockGroupName", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9114), false, null, "MAMUL GRUBU", null },
                    { 2, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9116), false, null, "MADEN GRUBU", null },
                    { 3, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9117), false, null, "HURDA GRUBU", null },
                    { 4, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9118), false, null, "PIRLANTA TAŞ GRUBU", null },
                    { 5, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9120), false, null, "ELMAS TAŞ GRUBU", null },
                    { 6, 1, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9121), false, null, "RENKLİ TAŞ GRUBU", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "BagliHesapID", "BarkodYaziciAdi", "CreatedByUserId", "CreatedDate", "Email", "FirstName", "FisYaziciAdi", "IsDeleted", "LastName", "ModifyDate", "Password", "Phone", "RoleId", "UpdatedByUserId", "VarsayilanYaziciAdi" },
                values: new object[,]
                {
                    { 1, true, null, null, 0, new DateTime(2026, 1, 1, 16, 50, 41, 148, DateTimeKind.Local).AddTicks(9899), "mahmut.kavalci@gmail.com", "Mahmut", null, false, "Kavalcı", null, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "+905353348460", 1, null, null },
                    { 2, true, null, null, 0, new DateTime(2026, 1, 1, 16, 50, 41, 149, DateTimeKind.Local).AddTicks(313), "samt51.m@icloud.com", "Samet", null, false, "Bağlan", null, "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "+905363956979", 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeDetails_BarcodeHeaderId",
                table: "BarcodeDetails",
                column: "BarcodeHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CurrencyId",
                table: "ExchangeRates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_AccountId",
                table: "Movements",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_CurrencyId",
                table: "Movements",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_ReceiptId",
                table: "Movements",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_StockId",
                table: "Movements",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_TransactionTypeId",
                table: "Movements",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_AccountId",
                table: "Receipts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockGroupId",
                table: "Stocks",
                column: "StockGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockTypeId",
                table: "Stocks",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_CurrencyId",
                table: "StockTypes",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_StockGroupId",
                table: "StockTypes",
                column: "StockGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssignedByUserId",
                table: "TaskItems",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssignedToUserId",
                table: "TaskItems",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarcodeDetails");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "ExchangeRateTickers");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "BarcodeHeaders");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "StockTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "StockGroups");
        }
    }
}
