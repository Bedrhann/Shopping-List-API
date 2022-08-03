using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Domain.Entities.Enums;
using FinalProject.Domain.Entities;
using Xunit;
using Moq;

namespace Teleperformance.FinalProject.Tests.UnitTests.ProductTests
{
    public class CreateProductCommandHandlerTest
    {
        [Fact]
        public async void CreateProduct_IsSuccess()
        {
            CreateProductCommandRequest productRequest = new CreateProductCommandRequest()
            {
                Name = "TestProduct",
                CategoryId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c") ,
                MeasurementType = MeasurementType.Kg,
                Quantity = 2
            };
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                CategoryId = productRequest.CategoryId,
                IsPurchased = false,
                Quantity = 2,
                MeasurementType = MeasurementType.Kg,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var mockRepo = new Mock<IProductCommandRepository>();
            mockRepo.Setup(c => c.AddAsync(It.IsAny<Product>())).ReturnsAsync(true);
            var command = new CreateProductCommandHandler(mockRepo.Object);

            CreateProductCommandResponse response = await command.Handle(productRequest, CancellationToken.None);

            Assert.True(response.Success);
            Assert.NotNull(response.Message);
        
        }
        [Fact]
        public async void CreateProduct_IsFailDataRequest()
        {
            CreateProductCommandRequest productRequest = new CreateProductCommandRequest()
            {
                Name = "TestProduct",
                CategoryId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c") ,
                MeasurementType = MeasurementType.Kg,
                Quantity = 2
            };
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "asdf",
                CategoryId = productRequest.CategoryId,
                IsPurchased = false,
                Quantity = 2,
                MeasurementType = MeasurementType.Kg,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            var mockRepo = new Mock<IProductCommandRepository>();
            mockRepo.Setup(c => c.AddAsync(product)).ReturnsAsync(false);
            mockRepo.Setup(c => c.SaveAsync());

            var command = new CreateProductCommandHandler(mockRepo.Object);

            CreateProductCommandResponse response = await command.Handle(productRequest, CancellationToken.None);

            Assert.False(response.Success);
            Assert.Null(response.Message);

        }
    }
}
