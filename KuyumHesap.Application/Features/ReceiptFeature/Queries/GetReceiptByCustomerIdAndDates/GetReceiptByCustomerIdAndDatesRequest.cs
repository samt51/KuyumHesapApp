using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetReceiptByCustomerIdAndDates
{
    public class GetReceiptByCustomerIdAndDatesRequest : IRequest<ResponseDto<List<GetReceiptByCustomerIdAndDatesResponse>>>
    {
        public GetReceiptByCustomerIdAndDatesRequest(int customerId, DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.CustomerId = customerId;
        }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
