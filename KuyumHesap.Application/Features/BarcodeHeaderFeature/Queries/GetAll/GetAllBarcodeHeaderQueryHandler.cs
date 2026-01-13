using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetAll
{
    public class GetAllBarcodeHeaderQueryHandler : BaseHandler, IRequestHandler<GetAllBarcodeHeaderQueryRequest, ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>>
    {
        public GetAllBarcodeHeaderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>> Handle(GetAllBarcodeHeaderQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new List<GetAllBarcodeHeaderQueryResponse>();
            var data = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAllAsync(x => !x.IsDeleted, include: y => y.Include(c => c.BarcodeDetails), orderBy: y => y.OrderBy(c => c.Name));

            var map = mapper.Map<List<GetAllBarcodeHeaderQueryResponse>>(data);

            return new ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>().Success(map);
        }
    }
}
