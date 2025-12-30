using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker
{
    public class GetPackerQueryHandler : BaseHandler, IRequestHandler<GetPackerQueryRequest, ResponseDto<List<GetPackerQueryResponse>>>
    {
        public GetPackerQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetPackerQueryResponse>>> Handle(GetPackerQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Account>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderBy(c => c.AccountName));

            var map = mapper.Map<GetPackerQueryResponse, Account>(data);

            return new ResponseDto<List<GetPackerQueryResponse>>().Success(map);
        }
    }
}
