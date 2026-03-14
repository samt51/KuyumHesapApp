using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Common.Models.Dtos
{
    public class CashReportModelResponseDto
    {
        public decimal TotalBalanceHas { get; set; }
        public List<CashRegisterStatusResponse> Details { get; set; } = new();
    }
}
