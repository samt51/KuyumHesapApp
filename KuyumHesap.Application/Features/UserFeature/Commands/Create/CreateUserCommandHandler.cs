using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Create
{
    public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommandRequest, ResponseDto<CreateUserCommandResponse>>
    {
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userNotFound = await unitOfWork.GetReadRepository<Users>().FindAsync(x => !x.IsDeleted && x.Email == request.Email);
            if (userNotFound is not null)
            {
                throw new Exception("Mail adrese uygun hesap bulunmaktadır.");
            }
            var maping = mapper.Map<Users, CreateUserCommandRequest>(request);

            maping.Password = PasswordHashExtension.HashPassword(request.Password);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Users>().AddAsync(maping);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateUserCommandResponse>().Success();
        }
    }
}
