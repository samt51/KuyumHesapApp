using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Commands.Create
{
    public class CreateCurrencyCommandHandler : BaseHandler, IRequestHandler<CreateCurrencyCommandRequest, ResponseDto<CreateCurrencyCommandResponse>>
    {
        public CreateCurrencyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateCurrencyCommandResponse>> Handle(CreateCurrencyCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<Currency, CreateCurrencyCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Currency>().AddAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateCurrencyCommandResponse>().Success();
        }
    }
}
