using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId
{
    public class GetEkstreByCustomerIdRequest : IRequest<ResponseDto<List<GetEkstreByCustomerIdResponse>>>
    {
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
