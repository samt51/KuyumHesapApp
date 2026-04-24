using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll
{
    public class GetAllRolesQueryHandler : BaseHandler, IRequestHandler<GetAllRolesQueryRequest, ResponseDto<List<GetAllRolesQueryResponse>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAllRolesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<List<GetAllRolesQueryResponse>>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roleIdStr = _httpContextAccessor.HttpContext?.User?
     .FindFirst("roleId")?.Value;

            int.TryParse(roleIdStr, out var currentUserRoleId);

            var data = await unitOfWork.GetReadRepository<KuyumHesap.Domain.Entities.Roles>()
                .GetAllAsync(c =>
                    !c.IsDeleted &&
                    (currentUserRoleId == 3 || c.Id == 1 || c.Id == 2)
                );

            var mapData = mapper.Map<List<GetAllRolesQueryResponse>>(data);
            
            foreach (var role in mapData)
            {
                if (role.Name == "SystemAdmin") role.Name = "Sistem Yönetici";
                else if (role.Name == "Admin") role.Name = "Yönetici";
                else if (role.Name == "User") role.Name = "Çalışan";
            }

            return new ResponseDto<List<GetAllRolesQueryResponse>>().Success(mapData);
        }
    }
}
