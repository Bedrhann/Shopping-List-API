using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities.Enums;
using MediatR;


namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public Guid CategoryId { get; set; }
    }
}
