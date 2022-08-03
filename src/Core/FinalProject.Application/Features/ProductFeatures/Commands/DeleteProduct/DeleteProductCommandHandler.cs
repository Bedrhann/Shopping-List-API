using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponse>
    {
        private readonly IProductQueryRepository _queryRepository;
        private readonly IProductCommandRepository _commandRepository;

        public DeleteProductCommandHandler(IProductQueryRepository queryRepository, IProductCommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<BaseResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            Product DeletedProduct = await _queryRepository.GetByIdAsync(request.Id.ToString());
            _commandRepository.Remove(DeletedProduct);
            _commandRepository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "Product Deleted"
            };
            return response;
            throw new NotImplementedException();
        }
    }
}
