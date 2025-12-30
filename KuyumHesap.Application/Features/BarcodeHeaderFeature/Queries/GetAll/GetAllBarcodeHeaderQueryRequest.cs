using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetAll
{
    public class GetAllBarcodeHeaderQueryRequest : IRequest<ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>>
    {
    }
}
