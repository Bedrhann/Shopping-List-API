using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllArchiveShopList
{
    public class GetAllArchiveShopListQueryResponse
    {
        public List<ShopListArchiveDto> Lists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
