using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetAll
{
    public class GetAllPageActionQueryHandler : BaseHandler, IRequestHandler<GetAllPageActionQueryRequest, ResponseDto<List<GetAllPageActionQueryResponse>>>
    {
        public GetAllPageActionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllPageActionQueryResponse>>> Handle(GetAllPageActionQueryRequest request, CancellationToken cancellationToken)
        {
            var pageActions = await unitOfWork.GetReadRepository<PageAction>().GetAllAsync(
                x => !x.IsDeleted,
                orderBy: x => x.OrderBy(y => y.PageCode).ThenBy(y => y.OrderNo),
                ct: cancellationToken);

            return new ResponseDto<List<GetAllPageActionQueryResponse>>().Success(
                pageActions.Select(Map).ToList());
        }

        private static GetAllPageActionQueryResponse Map(PageAction pageAction)
            => new()
            {
                Id = pageAction.Id,
                Name = pageAction.Name,
                Code = pageAction.Code,
                PageCode = pageAction.PageCode,
                IconUrl = pageAction.IconUrl,
                OrderNo = pageAction.OrderNo,
                RequiredPermissionCode = pageAction.RequiredPermissionCode
            };
    }
}
