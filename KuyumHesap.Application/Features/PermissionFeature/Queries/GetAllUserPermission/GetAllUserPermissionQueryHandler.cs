using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.UserFeature.Queries.GetAll;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetAllUserPermission
{
    public class GetAllUserPermissionQueryHandler : BaseHandler, IRequestHandler<GetAllUserPermissionQueryRequest, ResponseDto<List<GetAllUserPermissionQueryResponse>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAllUserPermissionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<List<GetAllUserPermissionQueryResponse>>> Handle(GetAllUserPermissionQueryRequest request, CancellationToken cancellationToken)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?
             .FindFirst("Id")?.Value;
            var roleIdStr = _httpContextAccessor.HttpContext?.User?
               .FindFirst("roleId")?.Value;

            int.TryParse(roleIdStr, out var currentUserRoleId);
            int.TryParse(userIdStr, out var currentUserId);


            var data = await unitOfWork.GetReadRepository<Users>().GetAllAsync(
                x => !x.IsDeleted && (currentUserRoleId == 3 || x.RoleId == 1 || x.RoleId == 2),
                include: y => y.Include(x => x.Role),
                ct: cancellationToken);

            var map = mapper.Map<GetAllUserQueryResponse, Users>(data);

            return new ResponseDto<List<GetAllUserPermissionQueryResponse>>().Success();
        }
    }
}
