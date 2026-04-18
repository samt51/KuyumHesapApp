using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetAll
{
    public class GetAllPermissionQueryHandler : BaseHandler, IRequestHandler<GetAllPermissionQueryRequest, ResponseDto<List<GetAllPermissionQueryResponse>>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAllPermissionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<List<GetAllPermissionQueryResponse>>> Handle(GetAllPermissionQueryRequest request, CancellationToken cancellationToken)
        {

            var roleIdStr = _httpContextAccessor.HttpContext?.User?
               .FindFirst("roleId")?.Value;

      

            int.TryParse(roleIdStr, out var currentUserRoleId);
       
            var permissions = (await unitOfWork.GetReadRepository<Permission>().GetAllAsync(
                x => !x.IsDeleted,
                orderBy: x => x.OrderBy(y => y.Code),
                ct: cancellationToken)).ToList();

            if(currentUserRoleId == 1|| currentUserRoleId == 2)
            {
                var blockedCodes = new[] { "SETTINGS_PAGE_ACTION", "SETTINGS_MENU" };
                permissions.RemoveAll(c => blockedCodes.Contains(c.Code));
            }

            var response = permissions.Select(x => new GetAllPermissionQueryResponse
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name
            }).ToList();

            return new ResponseDto<List<GetAllPermissionQueryResponse>>().Success(response);
        }
    }
}
