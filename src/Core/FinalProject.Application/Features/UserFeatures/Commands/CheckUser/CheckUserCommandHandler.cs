using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Models.JwtToken;
using FinalProject.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Application.Features.UserFeatures.Commands.CheckUser
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommandRequest, CheckUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenerateToken _tokenGenerater;

        public CheckUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IGenerateToken tokenGenerater)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerater = tokenGenerater;
        }

        public async Task<CheckUserCommandResponse> Handle(CheckUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.Username);

            if (user == null)
                throw new Exception();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                List<Claim> claims = new List<Claim>();
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                claims.Add(new Claim("Id", user.Id));

                Token token = _tokenGenerater.CreateAccessToken(5,claims);
                return new CheckUserCommandResponse()
                {
                    Token = token
                };
            }
                throw new NotImplementedException();
        }
    }
}
