using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetById
{
    public class GetByIdExchangeQueryHandler : BaseHandler, IRequestHandler<GetByIdExchangeQueryRequest, ResponseDto<GetByIdExchangeQueryResponse>>
    {
        public GetByIdExchangeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdExchangeQueryResponse>> Handle(GetByIdExchangeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ExchangeRate>().GetAsync(x => !x.IsDeleted && x.Id == request.Id,y=>y.Include(c=>c.Currency));

            var map = mapper.Map<GetByIdExchangeQueryResponse, ExchangeRate>(data);

            return new ResponseDto<GetByIdExchangeQueryResponse>().Success(map);
        }
    }
}
