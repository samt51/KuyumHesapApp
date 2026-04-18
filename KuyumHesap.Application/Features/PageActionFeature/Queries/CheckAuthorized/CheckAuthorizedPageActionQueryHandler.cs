using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.CheckAuthorized
{
    public class CheckAuthorizedPageActionQueryHandler : BaseHandler, IRequestHandler<CheckAuthorizedPageActionQueryRequest, ResponseDto<CheckAuthorizedPageActionQueryResponse>>
    {
        public CheckAuthorizedPageActionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CheckAuthorizedPageActionQueryResponse>> Handle(CheckAuthorizedPageActionQueryRequest request, CancellationToken cancellationToken)
        {
            var pageAction = await unitOfWork.GetReadRepository<PageAction>().GetAsync(
                x => !x.IsDeleted && x.PageCode == request.PageCode && x.Code == request.ActionCode);

            var isAuthorized = string.IsNullOrWhiteSpace(pageAction.RequiredPermissionCode);

            if (!isAuthorized)
            {
                var user = await unitOfWork.GetReadRepository<Users>().GetAsync(x => x.Id == request.UserId && !x.IsDeleted);
                var permissionCodes = await GetEffectivePermissionCodesAsync(user.Id, user.RoleId, cancellationToken);
                isAuthorized = permissionCodes.Contains(pageAction.RequiredPermissionCode);
            }

            return new ResponseDto<CheckAuthorizedPageActionQueryResponse>().Success(new CheckAuthorizedPageActionQueryResponse
            {
                IsAuthorized = isAuthorized,
                PageCode = pageAction.PageCode,
                ActionCode = pageAction.Code,
                RequiredPermissionCode = pageAction.RequiredPermissionCode
            });
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
    }
}
