using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.GetAll
{
    public class GetAllAccountQueryRequest : IRequest<ResponseDto<List<GetAllAccountQueryResponse>>>
    {
        public string AccountTypeName { get; set; } = string.Empty;
    }
}
