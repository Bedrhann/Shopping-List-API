using FinalProject.Application.Wrappers.Responses;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("newProductId")]
        public Guid NewProductId { get; set; }
    }
}
