using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById
{
    public class GetByIdReceiptQueryRequest : IRequest<ResponseDto<GetByIdReceiptQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdReceiptQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
