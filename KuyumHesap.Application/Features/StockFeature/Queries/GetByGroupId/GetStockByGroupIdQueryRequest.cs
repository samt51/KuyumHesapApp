using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.StockFeature.Queries.GetAll;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetByGroupId
{
    public class GetStockByGroupIdQueryRequest : IRequest<ResponseDto<List<GetAllStockQueryResponse>>>
    {
        public int GroupId { get; set; }
        public GetStockByGroupIdQueryRequest(int groupId)
        {
            GroupId = groupId;
        }
    }
}
