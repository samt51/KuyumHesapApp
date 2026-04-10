using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Command.DeleteAllSystem
{
    public class DeleteAllSystemCommandHandler : BaseHandler, IRequestHandler<DeleteAllSystemCommandRequest, ResponseDto<DeleteAllSystemCommandResponse>>
    {
        public DeleteAllSystemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteAllSystemCommandResponse>> Handle(DeleteAllSystemCommandRequest request, CancellationToken cancellationToken)
        {
            var movementData = await unitOfWork.GetReadRepository<Movements>().GetAllAsync();
            await unitOfWork.GetWriteRepository<Movements>().HardDeleteRangeAsync(movementData);

            var receiptData = await unitOfWork.GetReadRepository<Receipt>().GetAllAsync();

            await unitOfWork.GetWriteRepository<Receipt>().HardDeleteRangeAsync(receiptData);

            await unitOfWork.SaveAsync();

            return new ResponseDto<DeleteAllSystemCommandResponse>().Success();
        }
    }
}
