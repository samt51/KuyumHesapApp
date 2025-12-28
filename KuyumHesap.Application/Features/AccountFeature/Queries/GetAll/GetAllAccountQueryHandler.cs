using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.GetAll
{
    public class GetAllAccountQueryHandler : BaseHandler, IRequestHandler<GetAllAccountQueryRequest, ResponseDto<List<GetAllAccountQueryResponse>>>
    {
        public GetAllAccountQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllAccountQueryResponse>>> Handle(GetAllAccountQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
  
}
