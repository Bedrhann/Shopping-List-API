using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryResponse
    {
        public List<GetShopListDto> Lists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
