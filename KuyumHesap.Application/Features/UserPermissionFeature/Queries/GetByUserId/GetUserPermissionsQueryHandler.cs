using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Queries.GetByUserId
{
    public class GetUserPermissionsQueryHandler : BaseHandler, IRequestHandler<GetUserPermissionsQueryRequest, ResponseDto<List<GetUserPermissionsQueryResponse>>>
    {
        public GetUserPermissionsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetUserPermissionsQueryResponse>>> Handle(GetUserPermissionsQueryRequest request, CancellationToken cancellationToken)
        {
            var userPermissions = await unitOfWork.GetReadRepository<UserPermission>().GetAllAsync(
                x => x.UserId == request.UserId && !x.IsDeleted,
                include: x => x.Include(y => y.Permission),
                ct: cancellationToken);

            var response = userPermissions.Select(x => new GetUserPermissionsQueryResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                PermissionId = x.PermissionId,
                PermissionCode = x.Permission?.Code ?? string.Empty,
                PermissionName = x.Permission?.Name ?? string.Empty,
                IsAllowed = x.IsAllowed
            }).ToList();

            return new ResponseDto<List<GetUserPermissionsQueryResponse>>().Success(response);
        }
    }
}
