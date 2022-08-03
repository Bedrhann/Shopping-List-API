using FinalProject.Application.Wrappers.Responses;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse :BaseResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("newCategoryId")]
        public Guid NewCategoryId { get; set; }
    }
}
