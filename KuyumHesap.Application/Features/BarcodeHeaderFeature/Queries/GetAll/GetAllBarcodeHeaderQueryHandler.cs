using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

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
            var data = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderBy(c => c.Name));

            foreach (var item in data)
            {
                rsp.Add(new GetAllBarcodeHeaderQueryResponse
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return new ResponseDto<List<GetAllBarcodeHeaderQueryResponse>>().Success();
        }
    }
}
