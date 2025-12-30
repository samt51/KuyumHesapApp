using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetById
{
    public class GetByIdAccountTypeQueryHandler : BaseHandler, IRequestHandler<GetByIdAccountTypeQueryRequest, ResponseDto<GetByIdAccountTypeQueryResponse>>
    {
        public GetByIdAccountTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdAccountTypeQueryResponse>> Handle(GetByIdAccountTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<AccountType>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<GetByIdAccountTypeQueryResponse, AccountType>(data);

            return new ResponseDto<GetByIdAccountTypeQueryResponse>().Success(map);
        }
    }
}
