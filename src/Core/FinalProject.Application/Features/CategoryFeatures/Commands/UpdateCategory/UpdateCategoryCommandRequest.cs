using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
