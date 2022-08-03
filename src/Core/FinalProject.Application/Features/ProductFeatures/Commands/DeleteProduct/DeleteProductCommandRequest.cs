using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
