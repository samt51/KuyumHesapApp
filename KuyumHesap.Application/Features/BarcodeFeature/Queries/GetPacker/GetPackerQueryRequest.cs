using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker
{
    public class GetPackerQueryRequest : IRequest<ResponseDto<List<GetPackerQueryResponse>>>
    {
    }
}
