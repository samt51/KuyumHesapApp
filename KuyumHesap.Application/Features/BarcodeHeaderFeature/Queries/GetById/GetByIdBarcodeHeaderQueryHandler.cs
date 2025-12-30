using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById
{
    public class GetByIdBarcodeHeaderQueryHandler : BaseHandler, IRequestHandler<GetByIdBarcodeHeaderQueryRequest, ResponseDto<GetByIdBarcodeHeaderQueryResponse>>
    {
        public GetByIdBarcodeHeaderQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdBarcodeHeaderQueryResponse>> Handle(GetByIdBarcodeHeaderQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new GetByIdBarcodeHeaderQueryResponse();
            Expression<Func<BarcodeHeader, bool>> predicate = x => !x.IsDeleted && x.Id == request.Id;

            var data = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAsync(predicate, include: q => q.Include(c => c.BarcodeDetails));

            if (data.BarcodeDetails.Any())
            {
                rsp = new GetByIdBarcodeHeaderQueryResponse
                {
                    Id = data.Id,
                    Name = data.Name,
                    StartHeight = data.StartHeight,
                    StartWidth = data.StartWidth,
                    IsRfid = data.IsRfid,
                    barcodeDetails = new List<Dtos.BarcodeDetailResponseDto>()
                };
            }
            else
            {
                var mapDetail = mapper.Map<BarcodeDetailResponseDto, BarcodeDetail>(data.BarcodeDetails);
                var map = mapper.Map<GetByIdBarcodeHeaderQueryResponse, BarcodeHeader>(data);
                rsp = map;
                rsp.barcodeDetails = mapDetail;
            }

            return new ResponseDto<GetByIdBarcodeHeaderQueryResponse>().Success(rsp);

        }
    }
}
