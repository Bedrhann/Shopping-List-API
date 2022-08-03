using FinalProject.Application.Models.JwtToken;
using System.Security.Claims;


namespace FinalProject.Application.Interfaces.Services
{
    public interface IGenerateToken
    {
        Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
