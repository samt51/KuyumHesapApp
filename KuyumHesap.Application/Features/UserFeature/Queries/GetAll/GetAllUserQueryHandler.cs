using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.UserFeature.Queries.GetAll
{
    public class GetAllUserQueryHandler : BaseHandler, IRequestHandler<GetAllUserQueryRequest, ResponseDto<List<GetAllUserQueryResponse>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<List<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var roleIdStr = _httpContextAccessor.HttpContext?.User?
                .FindFirst("roleId")?.Value;

            int.TryParse(roleIdStr, out var currentUserRoleId);

            currentUserRoleId = 3;
            var data = await unitOfWork.GetReadRepository<Users>().GetAllAsync(
                x => !x.IsDeleted && (currentUserRoleId == 3 || x.RoleId == 1 || x.RoleId == 2),
                include: y => y.Include(x => x.Role),
                ct: cancellationToken);

            var map = mapper.Map<GetAllUserQueryResponse, Users>(data);

            return new ResponseDto<List<GetAllUserQueryResponse>>().Success(map);
        }
    }
}
