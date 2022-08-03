using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Models.Paging;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllArchiveShopList
{
    public class GetAllArchiveShopListQueryHandler : IRequestHandler<GetAllArchiveShopListQueryRequest, GetAllArchiveShopListQueryResponse>
    {
        private readonly IShopListQueryArchiveRepository _repository;

        public GetAllArchiveShopListQueryHandler(IShopListQueryArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllArchiveShopListQueryResponse> Handle(GetAllArchiveShopListQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ShopListArchiveDto> Lists = _repository.GetAll();
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
            List<ShopListArchiveDto> ShopLists = Lists.Skip(Skip).Take(request.Limit).ToList();
            return new GetAllArchiveShopListQueryResponse()
            {
                PagingInfo = PageInfo,
                Lists = ShopLists
            };
        }
    }
}
