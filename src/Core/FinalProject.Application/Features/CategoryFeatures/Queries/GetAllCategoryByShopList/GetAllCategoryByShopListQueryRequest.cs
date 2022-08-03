using FinalProject.Application.Wrappers.Queries;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryRequest : BasePagingRequest, IRequest<GetAllCategoryByShopListQueryResponse>
    {
        public Guid ShopListId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
    }
}
