using FinalProject.Application.Wrappers.Responses;
using MediatR;


namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandRequest : IRequest<BaseResponse>
    {
        public Guid? AppUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
