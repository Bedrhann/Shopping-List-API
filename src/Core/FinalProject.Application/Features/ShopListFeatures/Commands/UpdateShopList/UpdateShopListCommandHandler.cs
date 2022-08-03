using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Interfaces.Services.RabbitMQService;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList
{
    public class UpdateShopListCommandHandler : IRequestHandler<UpdateShopListCommandRequest, BaseResponse>
    {
        private readonly IShopListCommandRepository _commandRepository;
        private readonly IShopListQueryRepository _queryRepository;
        private readonly IRabbitMqPublisher _rabbitMq;

        public UpdateShopListCommandHandler(IShopListCommandRepository commandRepository, IShopListQueryRepository queryRepository, IRabbitMqPublisher rabbitMq)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _rabbitMq = rabbitMq;
        }


        public async Task<BaseResponse> Handle(UpdateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            ShopList UpdatedShopList = await _queryRepository.GetByIdAsync(request.Id.ToString());
            bool oldStatus = UpdatedShopList.IsCompleted;
            request.Adapt<UpdateShopListCommandRequest, ShopList>(UpdatedShopList);
            _commandRepository.Update(UpdatedShopList);
            await _commandRepository.SaveAsync();
            if (oldStatus == false && UpdatedShopList.IsCompleted == true)
            {
                UpdatedShopList.Adapt<ShopList, ShopListArchiveDto>();
                _rabbitMq.Publish(UpdatedShopList, "fanout.shoplist");
            }
            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
