using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AuthFeature.Commands.Register
{
    public class RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : BaseHandler(mapper, unitOfWork),
    IRequestHandler<RegisterCommandRequest, ResponseDto<RegisterCommandResponse>>
    {
        public async Task<ResponseDto<RegisterCommandResponse>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<Users, RegisterCommandRequest>(request);

         

            await unitOfWork.GetReadRepository<Users>().FindAsync(y => y.UserName == request.UserName && !y.IsDeleted);

            user.Password = PasswordHashExtension.HashPassword(request.Password);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Users>().AddAsync(user, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<RegisterCommandResponse>().Success();
        }
    }
}