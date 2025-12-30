using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.CheckUniqueness
{
    public class CheckUniquenessQueryRequest : IRequest<ResponseDto<CheckUniquenessQueryResponse>>
    {
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int CurrentId { get; set; } = 0;
    }
}
