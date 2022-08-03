using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById
{
    public class GetShopListByIdQueryHandler : IRequestHandler<GetShopListByIdQueryRequest, GetShopListByIdQueryResponse>
    {
        private readonly IShopListQueryRepository _repository;

        public GetShopListByIdQueryHandler(IShopListQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetShopListByIdQueryResponse> Handle(GetShopListByIdQueryRequest request, CancellationToken cancellationToken)
        {
            ShopList ShopList = await _repository.GetByIdAsync(request.Id.ToString());
            GetShopListDto ShopListDto = ShopList.Adapt<GetShopListDto>();

            return new GetShopListByIdQueryResponse()
            {
                ShopList = ShopListDto
            };
            throw new NotImplementedException();
        }
    }
}
