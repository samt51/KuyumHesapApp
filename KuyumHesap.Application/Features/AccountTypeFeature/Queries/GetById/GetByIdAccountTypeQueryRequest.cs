using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetById
{
    public class GetByIdAccountTypeQueryRequest : IRequest<ResponseDto<GetByIdAccountTypeQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdAccountTypeQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
