using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public Guid ShopListId { get; set; }
        public string Name { get; set; }
    }
}
