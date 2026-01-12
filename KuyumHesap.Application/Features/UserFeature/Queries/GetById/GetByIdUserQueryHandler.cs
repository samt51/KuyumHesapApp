using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KuyumHesap.Application.Features.UserFeature.Queries.GetById
{
    public class GetByIdUserQueryHandler : BaseHandler, IRequestHandler<GetByIdUserQueryRequest, ResponseDto<GetByIdUserQueryResponse>>
    {
        public GetByIdUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdUserQueryResponse>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Users>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map<GetByIdUserQueryResponse, Users>(data);

            return new ResponseDto<GetByIdUserQueryResponse>().Success(map);
        }
    }
}
