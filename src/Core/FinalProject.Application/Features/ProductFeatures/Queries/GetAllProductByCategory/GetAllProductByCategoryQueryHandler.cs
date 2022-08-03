using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.DTOs.Product;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryHandler : IRequestHandler<GetAllProductByCategoryQueryRequest, GetAllProductByCategoryQueryResponse>
    {
        private readonly IProductQueryRepository _repository;

        public GetAllProductByCategoryQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductByCategoryQueryResponse> Handle(GetAllProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            IQueryable<Product> Products = _repository.GetWhere(x => x.CategoryId == request.CategoryId);

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Products = Products.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Products = Products.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Products = Products.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.CreationRangeLower);
            }

            int TotalUser = Products.Count();
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

            List<Product> ProductList = Products.Skip(Skip).Take(request.Limit).ToList();
            List<GetProductDto> ProductDtoList = ProductList.Adapt<List<GetProductDto>>();
            return new GetAllProductByCategoryQueryResponse()
            {
                PagingInfo = PageInfo,
                Products = ProductDtoList
            };
        }
    }
}
