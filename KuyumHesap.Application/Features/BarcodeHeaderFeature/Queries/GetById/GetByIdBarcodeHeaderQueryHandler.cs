using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById
{
    public class GetByIdBarcodeHeaderQueryHandler : BaseHandler, IRequestHandler<GetByIdBarcodeHeaderQueryRequest, ResponseDto<GetByIdBarcodeHeaderQueryResponse>>
    {
        public GetByIdBarcodeHeaderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdBarcodeHeaderQueryResponse>> Handle(GetByIdBarcodeHeaderQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAsync(x => !x.IsDeleted && x.Id == request.Id, include: y => y.Include(c => c.BarcodeDetails));

            var map = mapper.Map<GetByIdBarcodeHeaderQueryResponse>(datas);

            return new ResponseDto<GetByIdBarcodeHeaderQueryResponse>().Success(map);
        }
    }
}
