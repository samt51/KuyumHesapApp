using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.CheckSoftDuplicate
{
    public class CheckSoftDuplicateQueryRequest : IRequest<ResponseDto<CheckSoftDuplicateQueryResponse>>
    {
        public string AccountName { get; set; } = string.Empty;
        public int CurrentId { get; set; }
    }
}
