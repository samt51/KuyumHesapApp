using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Commands.Update
{
    public class UpdateExchangeCommandHandler : BaseHandler, IRequestHandler<UpdateExchangeCommandRequest, ResponseDto<UpdateExchangeCommandResponse>>
    {
        public UpdateExchangeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateExchangeCommandResponse>> Handle(UpdateExchangeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Currency>().UpdateAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateExchangeCommandResponse>().Success();


        }
    }
}
