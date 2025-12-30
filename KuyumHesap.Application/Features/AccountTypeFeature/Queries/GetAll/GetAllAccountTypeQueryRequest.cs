using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetAll
{
    public class GetAllAccountTypeQueryRequest :IRequest<ResponseDto<List<GetAllAccountTypeQueryResponse>>>
    {
    }
}
