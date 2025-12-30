using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll
{
    public class GetAllExchangeQueryRequest : IRequest<ResponseDto<List<GetAllExchangeQueryResponse>>>
    {
    }
}
