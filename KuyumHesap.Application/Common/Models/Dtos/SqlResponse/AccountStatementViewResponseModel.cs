namespace KuyumHesap.Application.Common.Models.Dtos.SqlResponse
{
    public class AccountStatementViewResponseModel
    {
        public int MovementId { get; set; }
        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int AccountId { get; set; }
        public string TransactionName { get; set; } = string.Empty;
        public string AccountName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public decimal CounterQuantity { get; set; }
        public string CounterUnit { get; set; } = string.Empty;
        public decimal CounterRate { get; set; }
        public int? StockId { get; set; }
        public string? StockName { get; set; }
        public decimal? MillRate { get; set; }
        public decimal? LaborCost { get; set; }
        public string? LaborUnit { get; set; }
        public int? LaborQuantity { get; set; }
        public bool IsLaborIncluded { get; set; }
        public decimal? NetProductValue { get; set; }
        public decimal? TotalLaborCost { get; set; }
        public decimal BalanceEffectAmount { get; set; }
        public string BalanceUnit { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsReconciled { get; set; }
        public bool IsEntry { get; set; }
        public string? StockUnit { get; set; }
        public int? AccountTypeId { get; set; }
        public string? AccountTypeName { get; set; }
        public int ReceiptAccounId { get; set; }
        public string ReceiptAccountName { get; set; }
        public string ReceiptAccounTypeName { get; set; }
        public int TransactionTypeId { get; set; }
        public bool? IsCustomerReceipt { get; set; }
    }
}