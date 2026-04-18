using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetByPageCode
{
    public class GetPageActionsByPageCodeQueryHandler : BaseHandler, IRequestHandler<GetPageActionsByPageCodeQueryRequest, ResponseDto<List<GetPageActionsByPageCodeQueryResponse>>>
    {
        public GetPageActionsByPageCodeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetPageActionsByPageCodeQueryResponse>>> Handle(GetPageActionsByPageCodeQueryRequest request, CancellationToken cancellationToken)
        {
            var pageActions = await unitOfWork.GetReadRepository<PageAction>().GetAllAsync(
                x => !x.IsDeleted && x.PageCode == request.PageCode,
                orderBy: x => x.OrderBy(y => y.OrderNo),
                ct: cancellationToken);

            return new ResponseDto<List<GetPageActionsByPageCodeQueryResponse>>().Success(
                pageActions.Select(x => new GetPageActionsByPageCodeQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    PageCode = x.PageCode,
                    IconUrl = x.IconUrl,
                    OrderNo = x.OrderNo,
                    RequiredPermissionCode = x.RequiredPermissionCode
                }).ToList());
        }
    }
}
