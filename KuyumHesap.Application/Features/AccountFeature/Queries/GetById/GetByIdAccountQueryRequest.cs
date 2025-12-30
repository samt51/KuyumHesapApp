using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.GetById
{
    public class GetByIdAccountQueryRequest : IRequest<ResponseDto<GetByIdAccountQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdAccountQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
