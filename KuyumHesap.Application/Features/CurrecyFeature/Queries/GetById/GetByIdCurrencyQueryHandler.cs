using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Queries.GetById
{
    public class GetByIdCurrencyQueryHandler : BaseHandler, IRequestHandler<GetByIdCurrencyQueryRequest, ResponseDto<GetByIdCurrencyQueryResponse>>
    {
        public GetByIdCurrencyQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdCurrencyQueryResponse>> Handle(GetByIdCurrencyQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map<GetByIdCurrencyQueryResponse, Currency>(data);

            return new ResponseDto<GetByIdCurrencyQueryResponse>().Success(map);
        }
    }
}
