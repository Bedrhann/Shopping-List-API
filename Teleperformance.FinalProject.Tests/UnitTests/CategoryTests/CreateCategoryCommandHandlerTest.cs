using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Moq;
using Xunit;

namespace Teleperformance.FinalProject.Tests.UnitTests.CategoryTests
{
    public class CreateCategoryCommandHandlerTest
    {
        [Fact]
        public async void CreateCategory_IsSuccess()
        {
            CreateCategoryCommandRequest categoryRequest = new CreateCategoryCommandRequest()
            {
                Name = "TestCategory",
                ShopListId = Guid.NewGuid(),
            };
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                ShopListId = categoryRequest.ShopListId,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            var mockRepo = new Mock<ICategoryCommandRepository>();
            mockRepo.Setup(c => c.AddAsync(It.IsAny<Category>())).ReturnsAsync(true);
            var command = new CreateCategoryCommandHandler(mockRepo.Object);

            BaseResponse response = await command.Handle(categoryRequest, CancellationToken.None);
            Assert.True(response.Success);
            Assert.NotNull(response.Message);
        }

        [Fact]
        public async void CreateCategory_IsFailDataRequest()
        {
            CreateCategoryCommandRequest categoryRequest = new CreateCategoryCommandRequest()
            {
                Name = "TestCategory",
                ShopListId = Guid.NewGuid(),
            };
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                ShopListId = categoryRequest.ShopListId,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
            var mockRepo = new Mock<ICategoryCommandRepository>();
            mockRepo.Setup(c => c.AddAsync(category)).ReturnsAsync(false);
            mockRepo.Setup(c => c.SaveAsync());
            var command = new CreateCategoryCommandHandler(mockRepo.Object);

            BaseResponse response = await command.Handle(categoryRequest, CancellationToken.None);
            Assert.False(response.Success);
            Assert.Null(response.Message);
        }
    }
}
