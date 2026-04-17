using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAll
{
    public class GetAllMenuQueryHandler : BaseHandler, IRequestHandler<GetAllMenuQueryRequest, ResponseDto<List<GetAllMenuQueryResponse>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllMenuQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<List<GetAllMenuQueryResponse>>> Handle(GetAllMenuQueryRequest request, CancellationToken cancellationToken)
        {
            var roleIdStr = _httpContextAccessor.HttpContext?.User?
                .FindFirst("roleId")?.Value;

            var userIdStr = _httpContextAccessor.HttpContext?.User?
                .FindFirst("Id")?.Value;

            int.TryParse(roleIdStr, out var currentUserRoleId);
            int.TryParse(userIdStr, out var currentUserId);

            var menus = await unitOfWork.GetReadRepository<Menu>().GetAllAsync(
                x => !x.IsDeleted && (currentUserRoleId == 3 || x.IsActive),
                orderBy: x => x.OrderBy(y => y.OrderNo),
                ct: cancellationToken);

            if (currentUserRoleId == 2)
            {
                var permissionCodes = await GetEffectivePermissionCodesAsync(currentUserId, currentUserRoleId, cancellationToken);
                menus = IncludeAuthorizedMenusAndParents(menus, permissionCodes);
            }

            return new ResponseDto<List<GetAllMenuQueryResponse>>().Success(BuildTree(menus));
        }

        private async Task<HashSet<string>> GetEffectivePermissionCodesAsync(int userId, int roleId, CancellationToken cancellationToken)
        {
            var rolePermissions = await unitOfWork.GetReadRepository<RolePermission>().GetAllAsync(
                x => !x.IsDeleted && x.RoleId == roleId,
                include: x => x.Include(y => y.Permission),
                ct: cancellationToken);

            var permissionCodes = rolePermissions
                .Where(x => x.Permission is not null && !x.Permission.IsDeleted)
                .Select(x => x.Permission.Code)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (userId <= 0)
            {
                return permissionCodes;
            }

            var userPermissions = await unitOfWork.GetReadRepository<UserPermission>().GetAllAsync(
                x => !x.IsDeleted && x.UserId == userId,
                include: x => x.Include(y => y.Permission),
                ct: cancellationToken);

            foreach (var userPermission in userPermissions.Where(x => x.Permission is not null && !x.Permission.IsDeleted))
            {
                if (userPermission.IsAllowed)
                {
                    permissionCodes.Add(userPermission.Permission.Code);
                }
                else
                {
                    permissionCodes.Remove(userPermission.Permission.Code);
                }
            }

            return permissionCodes;
        }

        private static List<Menu> IncludeAuthorizedMenusAndParents(IList<Menu> menus, HashSet<string> permissionCodes)
        {
            var menuById = menus.ToDictionary(x => x.Id);
            var visibleIds = new HashSet<int>();

            foreach (var menu in menus)
            {
                var requiresPermission = !string.IsNullOrWhiteSpace(menu.RequeiredPermissionCode);
                if (requiresPermission && !permissionCodes.Contains(menu.RequeiredPermissionCode!))
                {
                    continue;
                }

                var current = menu;
                while (current is not null)
                {
                    visibleIds.Add(current.Id);
                    if (!current.ParentId.HasValue || !menuById.TryGetValue(current.ParentId.Value, out current))
                    {
                        break;
                    }
                }
            }

            return menus.Where(x => visibleIds.Contains(x.Id)).ToList();
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
                IsActive = menu.IsActive,
                RequeiredPermissionCode = menu.RequeiredPermissionCode
            };
    }
}
