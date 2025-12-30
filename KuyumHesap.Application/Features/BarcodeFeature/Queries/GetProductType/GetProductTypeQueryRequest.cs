using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType
{
    public class GetProductTypeQueryRequest : IRequest<ResponseDto<List<GetProductTypeQueryResponse>>>
    {

    }
}
