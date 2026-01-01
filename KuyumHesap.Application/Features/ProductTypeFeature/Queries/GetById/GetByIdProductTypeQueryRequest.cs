using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetById
{
    public class GetByIdProductTypeQueryRequest : IRequest<ResponseDto<GetByIdProductTypeQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdProductTypeQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
