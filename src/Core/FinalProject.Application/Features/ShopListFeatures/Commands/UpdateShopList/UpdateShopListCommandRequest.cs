using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList
{
    public class UpdateShopListCommandRequest : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
