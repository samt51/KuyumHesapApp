using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.UserFeature.Queries.GetAll
{
    public class GetAllUserQueryHandler : BaseHandler, IRequestHandler<GetAllUserQueryRequest, ResponseDto<List<GetAllUserQueryResponse>>>
    {
        public GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Users>().GetAllAsync(x => !x.IsDeleted,include:y=>y.Include(x=>x.Role));

            var map = mapper.Map<GetAllUserQueryResponse, Users>(data);

            return new ResponseDto<List<GetAllUserQueryResponse>>().Success(map);
        }
    }
}
