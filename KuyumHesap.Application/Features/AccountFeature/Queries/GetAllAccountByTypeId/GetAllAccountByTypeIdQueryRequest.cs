
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Feature.AccountFeature.Queries.GetAllAccountByTypeId
{
    public class GetAllAccountByTypeIdQueryRequest : IRequest<ResponseDto<List<GetAllAccountByTypeIdQueryResponse>>>
    {
        public int AccountTypeId { get; set; }
    }
}
