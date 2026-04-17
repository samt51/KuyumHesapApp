using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAll
{
    public class GetAllMenuQueryHandler : BaseHandler, IRequestHandler<GetAllMenuQueryRequest, ResponseDto<List<GetAllMenuQueryResponse>>>
    {
        public GetAllMenuQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllMenuQueryResponse>>> Handle(GetAllMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var menus = await unitOfWork.GetReadRepository<Menu>().GetAllAsync(
                x => !x.IsDeleted,
                orderBy: x => x.OrderBy(y => y.OrderNo),
                ct: cancellationToken);

            return new ResponseDto<List<GetAllMenuQueryResponse>>().Success(BuildTree(menus));
        }

        private static List<GetAllMenuQueryResponse> BuildTree(IList<Menu> menus)
        {
            var lookup = menus.ToDictionary(x => x.Id, Map);

            foreach (var menu in menus.Where(x => x.ParentId.HasValue))
            {
                if (lookup.TryGetValue(menu.ParentId!.Value, out var parent))
                {
                    parent.Children.Add(lookup[menu.Id]);
                }
            }

            return menus
                .Where(x => !x.ParentId.HasValue)
                .OrderBy(x => x.OrderNo)
                .Select(x => lookup[x.Id])
                .ToList();
        }

        private static GetAllMenuQueryResponse Map(Menu menu)
            => new()
            {
                Id = menu.Id,
                ParentId = menu.ParentId,
                Name = menu.Name,
                Code = menu.Code,
                Url = menu.Url,
                IconUrl = menu.IconUrl,
                OrderNo = menu.OrderNo,
                RequeiredPermissionCode = menu.RequeiredPermissionCode
            };
    }
}
