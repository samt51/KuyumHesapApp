using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetAuthorized
{
    public class GetAuthorizedPageActionsQueryHandler : BaseHandler, IRequestHandler<GetAuthorizedPageActionsQueryRequest, ResponseDto<List<GetAuthorizedPageActionsQueryResponse>>>
    {
        public GetAuthorizedPageActionsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAuthorizedPageActionsQueryResponse>>> Handle(GetAuthorizedPageActionsQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<Users>().GetAsync(x => x.Id == request.UserId && !x.IsDeleted);
            var permissionCodes = await GetEffectivePermissionCodesAsync(user.Id, user.RoleId, cancellationToken);

            var pageActions = await unitOfWork.GetReadRepository<PageAction>().GetAllAsync(
                x => !x.IsDeleted && x.PageCode == request.PageCode,
                orderBy: x => x.OrderBy(y => y.OrderNo),
                ct: cancellationToken);

            var response = pageActions
                .Where(x => string.IsNullOrWhiteSpace(x.RequiredPermissionCode) || permissionCodes.Contains(x.RequiredPermissionCode))
                .Select(x => new GetAuthorizedPageActionsQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    PageCode = x.PageCode,
                    IconUrl = x.IconUrl,
                    OrderNo = x.OrderNo,
                    RequiredPermissionCode = x.RequiredPermissionCode
                })
                .ToList();

            return new ResponseDto<List<GetAuthorizedPageActionsQueryResponse>>().Success(response);
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
