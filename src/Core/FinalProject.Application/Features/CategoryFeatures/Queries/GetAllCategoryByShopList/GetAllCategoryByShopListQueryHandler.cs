using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryHandler : IRequestHandler<GetAllCategoryByShopListQueryRequest, GetAllCategoryByShopListQueryResponse>
    {
        private readonly ICategoryQueryRepository _repository;

        public GetAllCategoryByShopListQueryHandler(ICategoryQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoryByShopListQueryResponse> Handle(GetAllCategoryByShopListQueryRequest request, CancellationToken cancellationToken)
        {

            IQueryable<Category> Categories = _repository.GetWhere(x => x.ShopListId == request.ShopListId);

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Categories = Categories.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Categories = Categories.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Categories = Categories.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.UpdateRangeLower);
            }

            int TotalUser = Categories.Count();
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

            List<Category> CategoryList = Categories.Skip(Skip).Take(request.Limit).ToList();
            List<GetCategoryDto> CategoryDtoList = CategoryList.Adapt<List<GetCategoryDto>>();
            return new GetAllCategoryByShopListQueryResponse()
            {
                PagingInfo = PageInfo,
                Categories = CategoryDtoList
            };
        }
    }
}
