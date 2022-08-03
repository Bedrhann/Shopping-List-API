using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponse>
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;

        public UpdateProductCommandHandler(IProductCommandRepository commandrepository, IProductQueryRepository queryrepository)
        {
            _commandRepository = commandrepository;
            _queryRepository = queryrepository;
        }

        public async Task<BaseResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product UpdatedProduct = await _queryRepository.GetByIdAsync(request.Id.ToString());
            request.Adapt<UpdateProductCommandRequest, Product>(UpdatedProduct);

            _commandRepository.Update(UpdatedProduct);
            await _commandRepository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "Product Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
