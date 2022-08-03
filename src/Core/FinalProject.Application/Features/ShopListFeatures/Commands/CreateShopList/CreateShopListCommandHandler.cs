using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandHandler : IRequestHandler<CreateShopListCommandRequest, BaseResponse>
    {
        private readonly IShopListCommandRepository _repository;

        public CreateShopListCommandHandler(IShopListCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(CreateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            ShopList NewShopList = request.Adapt<ShopList>();
            await _repository.AddAsync(NewShopList);
            await _repository.SaveAsync();

            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Added"
            };
            return response;
            throw new NotImplementedException();
        }
    }
}
