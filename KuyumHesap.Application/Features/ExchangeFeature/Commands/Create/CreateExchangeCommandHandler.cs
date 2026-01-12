using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Commands.Create
{
    public class CreateExchangeCommandHandler : BaseHandler, IRequestHandler<CreateExchangeCommandRequest, ResponseDto<CreateExchangeCommandResponse>>
    {
        public CreateExchangeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateExchangeCommandResponse>> Handle(CreateExchangeCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetReadRepository<Currency>().GetAsync(x => x.Id == request.CurrencyId && !x.IsDeleted);

            var map = mapper.Map<ExchangeRate, CreateExchangeCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateExchangeCommandResponse>().Success();
        }
    }
}
