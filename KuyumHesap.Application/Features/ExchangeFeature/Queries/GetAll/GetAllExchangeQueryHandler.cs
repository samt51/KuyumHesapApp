using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll
{
    public class GetAllExchangeQueryHandler : BaseHandler, IRequestHandler<GetAllExchangeQueryRequest, ResponseDto<List<GetAllExchangeQueryResponse>>>
    {
        public GetAllExchangeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllExchangeQueryResponse>>> Handle(GetAllExchangeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ExchangeRate>().GetAllAsync(x => !x.IsDeleted, y => y.Include(c => c.Currency));

            var map = mapper.Map<List<GetAllExchangeQueryResponse>>(data);

            return new ResponseDto<List<GetAllExchangeQueryResponse>>().Success(map);
        }
    }
}
