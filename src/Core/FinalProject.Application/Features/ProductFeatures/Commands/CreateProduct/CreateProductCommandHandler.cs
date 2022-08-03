using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductCommandRepository _repository;

        public CreateProductCommandHandler(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product NewProduct = request.Adapt<Product>();
            bool result = await _repository.AddAsync(NewProduct);
            await _repository.SaveAsync();
            CreateProductCommandResponse response = new();

            if (result)
            {
                response.NewProductId = NewProduct.Id;
                response.Success = true;
                response.Message = "Product Added";
            }
            return response;
        }
    }
}
