using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetById
{
    public class GetByIdPermissionQueryHandler : BaseHandler, IRequestHandler<GetByIdPermissionQueryRequest, ResponseDto<GetByIdPermissionQueryResponse>>
    {
        public GetByIdPermissionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdPermissionQueryResponse>> Handle(GetByIdPermissionQueryRequest request, CancellationToken cancellationToken)
        {
            var permission = await unitOfWork.GetReadRepository<Permission>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            return new ResponseDto<GetByIdPermissionQueryResponse>().Success(new GetByIdPermissionQueryResponse
            {
                Id = permission.Id,
                Code = permission.Code,
                Name = permission.Name
            });
        }
    }
}
