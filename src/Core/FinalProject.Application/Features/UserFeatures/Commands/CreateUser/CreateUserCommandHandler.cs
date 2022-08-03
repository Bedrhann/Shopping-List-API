using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //Veritabanına ilk kez admin ve user rollerini vermek için kullanıyoruz.
            //await _roleManager.CreateAsync(new AppRole { Id = "sdfsdfsfs", Name = "Admin" });
            //await _roleManager.CreateAsync(new AppRole { Id = "dfsdffsf", Name = "User" });
            AppUser NewUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                Email = request.Email,
                RegistrationDate = DateTime.UtcNow,
            };
            
            IdentityResult result = await _userManager.CreateAsync(NewUser, request.Password);
            await _userManager.AddToRoleAsync(NewUser, "User");

            BaseResponse response = new() { Success = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
           
            return response;
        }
    }
}
