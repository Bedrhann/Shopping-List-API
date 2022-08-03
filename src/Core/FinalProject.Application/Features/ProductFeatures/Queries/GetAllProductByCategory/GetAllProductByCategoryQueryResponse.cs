using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("products")]
        public List<GetProductDto> Products { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("pagingInfo")]
        public PagingInfo PagingInfo { get; set; }

    }
}
