using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryResponse
    {
        public List<GetCategoryDto> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
