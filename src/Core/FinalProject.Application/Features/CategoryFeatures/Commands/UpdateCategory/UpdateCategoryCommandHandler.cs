using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, BaseResponse>
    {
        private readonly ICategoryCommandRepository _commandRepository;
        private readonly ICategoryQueryRepository _queryRepository;

        public UpdateCategoryCommandHandler(ICategoryCommandRepository commandRepository, ICategoryQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<BaseResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category UpdatedCategory = await _queryRepository.GetByIdAsync(request.Id.ToString());
            request.Adapt<UpdateCategoryCommandRequest, Category>(UpdatedCategory);

            _commandRepository.Update(UpdatedCategory);
            await _commandRepository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "Category Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
