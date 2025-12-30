using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Update
{
    public class UpdateReceiptCommandHandler : BaseHandler, IRequestHandler<UpdateReceiptCommandRequest, ResponseDto<UpdateReceiptCommandResponse>>
    {
        public UpdateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateReceiptCommandResponse>> Handle(UpdateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var deleteByReceiptId = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(x => !x.IsDeleted && x.ReceiptId == request.Id);

            foreach (var item in deleteByReceiptId)
            {
                item.IsDeleted = true;
            }

            var updateReceiptMap = mapper.Map(request, data);

            for (int i = 0; i < updateReceiptMap.Movements.Count; i++)
            {
                var hareket1 = updateReceiptMap.Movements[i];
                var hareket2 = updateReceiptMap.Movements[i + 1];

                hareket1.ReceiptId = updateReceiptMap.Id;
                var hareket1Id = await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket1);


                hareket2.ReceiptId = updateReceiptMap.Id;
                hareket2.CounterTransactionId = hareket1Id.Id;
                var hareket2Id = await unitOfWork.GetWriteRepository<Movements>().AddAsync(hareket2);

                var movmentToUpdate = await unitOfWork.GetReadRepository<Movements>().GetAsync(x => !x.IsDeleted && x.CounterTransactionId == hareket1Id.Id && x.Id == hareket2Id.Id);

                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(movmentToUpdate);
            }
            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateReceiptCommandResponse>().Success();
        }
    }
}
