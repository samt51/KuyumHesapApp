using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Entities.VwModels;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById
{
    public class GetByIdReceiptQueryHandler : BaseHandler, IRequestHandler<GetByIdReceiptQueryRequest, ResponseDto<GetByIdReceiptQueryResponse>>
    {
        public GetByIdReceiptQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdReceiptQueryResponse>> Handle(GetByIdReceiptQueryRequest request, CancellationToken cancellationToken)
        {
            var receipt = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapReceipt = mapper.Map<GetByIdReceiptQueryResponse, Receipt>(receipt);

            var viewModel = await unitOfWork.GetReadRepository<EkstreSatirViewModel>().GetAllAsync(x => x.FisID == request.Id, orderBy: y => y.OrderBy(x => x.HareketID));

            mapReceipt.EkstreSatirViews = viewModel.ToList();

            if (mapReceipt.EkstreSatirViews.Any())
            {
                var hareketIDs = mapReceipt.EkstreSatirViews.Select(x => x.HareketID).ToList();

                var ekBilgiler = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(x => hareketIDs.Contains(x.Id));

                foreach (var item in mapReceipt.EkstreSatirViews)
                {
                    var movementId = item.HareketID;
                    var movementData = mapReceipt.EkstreSatirViews.FirstOrDefault(y => y.HareketID == movementId);
                    if (movementData != null)
                    {
                        movementData.HareketTipID = item.HareketTipID;
                        movementData.KarsiHareketID = item.KarsiHareketID;
                    }
                }

            }
            return new ResponseDto<GetByIdReceiptQueryResponse>().Success(mapReceipt);
        }
    }
}
