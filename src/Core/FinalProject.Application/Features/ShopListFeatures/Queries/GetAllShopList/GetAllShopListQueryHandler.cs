using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryHandler : IRequestHandler<GetAllShopListQueryRequest, GetAllShopListQueryResponse>
    {
        private readonly IShopListQueryRepository _repository;

        public GetAllShopListQueryHandler(IShopListQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllShopListQueryResponse> Handle(GetAllShopListQueryRequest request, CancellationToken cancellationToken)
        {

            IQueryable<ShopList> Lists = _repository.GetAll();
            if (request.IsCompleted)
            {
                Lists = Lists.Where(x => x.IsCompleted == true);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Lists = Lists.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.CreationRangeLower);
            }

            int TotalUser = Lists.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            PagingInfo PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };
            List<ShopList> ShopLists = Lists.Skip(Skip).Take(request.Limit).ToList();
            List<GetShopListDto> ShopListDtoList = ShopLists.Adapt<List<GetShopListDto>>();
            return new GetAllShopListQueryResponse()
            {
                PagingInfo = PageInfo,
                Lists = ShopListDtoList
            };
            //throw new NotImplementedException();
        }
    }
}
