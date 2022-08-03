using FinalProject.Application.Wrappers.Queries;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryRequest : BasePagingRequest, IRequest<GetAllProductByCategoryQueryResponse>
    {
        public Guid CategoryId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
    }
}
