using FinalProject.Application.Wrappers.Queries;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllArchiveShopList
{
    public class GetAllArchiveShopListQueryRequest : BasePagingRequest, IRequest<GetAllArchiveShopListQueryResponse>
    {
        public Guid? UserId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
        public bool IsCompleted { get; set; }
    }
}
