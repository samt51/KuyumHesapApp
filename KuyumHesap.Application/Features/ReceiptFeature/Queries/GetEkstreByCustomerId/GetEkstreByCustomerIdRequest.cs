using KuyumHesap.Application.Common.Models;
using MediatR;
using static KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId.GetEkstreByCustomerIdHandler;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId
{
    public class GetEkstreByCustomerIdRequest : IRequest<ResponseDto<EkstreViewModel>>
    {
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
