using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.GetById
{
    public class GetByIdAccountQueryHandler : BaseHandler, IRequestHandler<GetByIdAccountQueryRequest, ResponseDto<GetByIdAccountQueryResponse>>
    {
        public GetByIdAccountQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdAccountQueryResponse>> Handle(GetByIdAccountQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<GetByIdAccountQueryResponse, Account>(data);

            return new ResponseDto<GetByIdAccountQueryResponse>().Success(map);
        }

    }
}
