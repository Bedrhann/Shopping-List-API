using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList
{
    public class DeleteShopListCommandHandler : IRequestHandler<DeleteShopListCommandRequest, BaseResponse>
    {
        private readonly IShopListQueryRepository _queryRepository;
        private readonly IShopListCommandRepository _commandRepository;

        public DeleteShopListCommandHandler(IShopListCommandRepository commandrepository, IShopListQueryRepository queryrepository)
        {
            _commandRepository = commandrepository;
            _queryRepository = queryrepository;
        }

        public async Task<BaseResponse> Handle(DeleteShopListCommandRequest request, CancellationToken cancellationToken)
        {
            ShopList DeletedList = await _queryRepository.GetByIdAsync(request.Id.ToString());
            DeletedList.IsDeleted = true;
            _commandRepository.SaveAsync();

            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Deleted"
            };
            return response;
            throw new NotImplementedException();
        }


    }
}
