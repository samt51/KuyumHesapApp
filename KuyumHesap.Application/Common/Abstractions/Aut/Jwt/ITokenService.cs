using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KuyumHesap.Application.Common.Abstractions.Aut.Jwt
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(Users user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
        public Task<LoginCommandResponse> GenerateToken(GenerateTokenRequest roleRequest);

    }
}
