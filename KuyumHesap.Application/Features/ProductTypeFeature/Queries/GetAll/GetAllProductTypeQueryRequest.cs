using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetAll
{
    public class GetAllProductTypeQueryRequest : IRequest<ResponseDto<List<GetAllProductTypeQueryResponse>>>
    {
    }
}
