using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryCommandRepository _repository;

        public CreateCategoryCommandHandler(ICategoryCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category NewCategory = request.Adapt<Category>();
            bool result = await _repository.AddAsync(NewCategory);
            await _repository.SaveAsync();
            CreateCategoryCommandResponse response = new();

            if (result)
            {
                response.NewCategoryId = NewCategory.Id;
                response.Success = true;
                response.Message = "Category Added";
            }
            return response;
        }
    }
}
