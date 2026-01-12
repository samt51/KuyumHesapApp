using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Commands.Update
{
    public class UpdateCurrencyCommandHandler : BaseHandler, IRequestHandler<UpdateCurrencyCommandRequest, ResponseDto<UpdateCurrencyCommandResponse>>
    {
        public UpdateCurrencyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateCurrencyCommandResponse>> Handle(UpdateCurrencyCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Currency>().UpdateAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateCurrencyCommandResponse>().Success();
        }
    }
}
