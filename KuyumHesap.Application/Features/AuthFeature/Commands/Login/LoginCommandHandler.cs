using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Aut.Jwt;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.AuthFeature.Commands.Login
{
    public class LoginCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService) : BaseHandler(mapper, unitOfWork),
    IRequestHandler<LoginCommandRequest, ResponseDto<LoginCommandResponse>>
    {
        public async Task<ResponseDto<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.GetReadRepository<Users>().GetAsync(x => x.CompanyCode == request.BranchCode && x.UserName == request.UserName && x.Password == PasswordHashExtension.HashPassword(request.Password) && !x.IsDeleted,
                y => y.Include(x => x.Role));

            var token = await tokenService.GenerateToken(new GenerateTokenRequest(user.Id, user.UserName, user.RoleId, user.CompanyCode, user.BranchCode));

            var tkn = new LoginCommandResponse(token.Token, token.TokenExpireDate);

            return new ResponseDto<LoginCommandResponse>().Success(tkn);
        }
    }
}
