using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryQueryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Category Category = await _repository.GetByIdAsync(request.Id.ToString());
            GetCategoryDto CategoryDto = Category.Adapt<GetCategoryDto>();

            return new GetCategoryByIdQueryResponse()
            {
                Category = CategoryDto
            };

            throw new NotImplementedException();
        }
    }
}
