using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll
{
    public class GetAllReceiptQueryRequest : IRequest<ResponseDto<List<GetAllReceiptQueryResponse>>>
    {
        public bool IsCari { get; set; }
    }
}
