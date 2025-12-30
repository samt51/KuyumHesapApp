using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById
{
    public class GetByIdBarcodeHeaderQueryRequest : IRequest<ResponseDto<GetByIdBarcodeHeaderQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdBarcodeHeaderQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
