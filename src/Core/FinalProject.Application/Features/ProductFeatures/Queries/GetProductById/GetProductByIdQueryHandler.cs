using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IProductQueryRepository _repository;

        public GetProductByIdQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Product Product = await _repository.GetByIdAsync(request.Id.ToString());
            GetProductDto ProductDto = Product.Adapt<GetProductDto>();
            return new GetProductByIdQueryResponse()
            {
                Product = ProductDto
            };
            throw new NotImplementedException();
        }
    }
}
