using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Application.DTOs.Product;
using FinalProject.Domain.Entities.Enums;
using System.Text.Json;
using System.Text;
using Xunit;

namespace Teleperformance.FinalProject.Tests.IntegrationTests
{
    public class ProductsControllerTest : IClassFixture<FakeApplication>
    {
        private readonly HttpClient _httpClient;
        public ProductsControllerTest(FakeApplication factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async void ProductCrudProcess()
        {
            //GET****************
            GetAllProductByCategoryQueryRequest RequestGet = new GetAllProductByCategoryQueryRequest()
            {
                CategoryId =  Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c")
            };
            HttpResponseMessage responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            string contentGet = await responseGet.Content.ReadAsStringAsync();
            List<GetProductDto> commentGet = JsonSerializer.Deserialize<List<GetProductDto>>(contentGet);
            Assert.NotNull(commentGet);
            int firstCount = commentGet.Count();

            //CREATE****************
            CreateProductCommandRequest createRequest = new CreateProductCommandRequest()
            {
                CategoryId = RequestGet.CategoryId,
                MeasurementType = MeasurementType.Piece,
                Name = "asd",
                Quantity = 2
            };
            var bodyCreate = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseCreate = await _httpClient.PostAsync("/api/products", bodyCreate);
            responseCreate.EnsureSuccessStatusCode();
            string contentCreate = await responseCreate.Content.ReadAsStringAsync();
            CreateProductCommandResponse commentCreate = JsonSerializer.Deserialize<CreateProductCommandResponse>(contentCreate);
            Assert.NotNull(commentCreate);
            Assert.NotNull(commentCreate.Message);
            Assert.NotNull(commentCreate.NewProductId);
            Assert.True(commentCreate.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<List<GetProductDto>>(contentGet);
            Assert.NotNull(commentGet);
            int afterCreationCount = commentGet.Count();
            Assert.True((afterCreationCount - 1) == firstCount);

            //GETBYID**************
            HttpResponseMessage responseGetById = await _httpClient.GetAsync($"/api/products/{commentCreate.NewProductId}");
            responseGetById.EnsureSuccessStatusCode();
            string contentGetById = await responseGetById.Content.ReadAsStringAsync();
            GetProductDto commentGetById = JsonSerializer.Deserialize<GetProductDto>(contentGetById);
            Assert.NotNull(commentGetById);

            //UPDATE****************
            UpdateProductCommandRequest updateRequest = new UpdateProductCommandRequest()
            {
                Id = commentCreate.NewProductId,
                IsPurchased = false,
                MeasurementType = MeasurementType.Liter,
                Name = "nametest",
                Quantity = 3
            };
            var bodyUpdate = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseUpdate = await _httpClient.PutAsync("/api/products", bodyUpdate);
            responseUpdate.EnsureSuccessStatusCode();
            string contentUpdate = await responseUpdate.Content.ReadAsStringAsync();
            BaseResponse commentUpdate = JsonSerializer.Deserialize<BaseResponse>(contentUpdate);
            Assert.NotNull(commentUpdate);
            Assert.NotNull(commentUpdate.Message);
            Assert.True(commentUpdate.Success);

            //DELETE****************
            HttpResponseMessage responseDelete = await _httpClient.DeleteAsync($"/api/products/{commentCreate.NewProductId}");
            responseDelete.EnsureSuccessStatusCode();
            string contentDelete = await responseDelete.Content.ReadAsStringAsync();
            BaseResponse commentDelete = JsonSerializer.Deserialize<BaseResponse>(contentDelete);
            Assert.NotNull(commentDelete);
            Assert.NotNull(commentDelete.Message);
            Assert.True(commentDelete.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.CategoryId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<List<GetProductDto>>(contentGet);
            Assert.NotNull(commentGet);
            int lastCount = commentGet.Count();

            Assert.True(lastCount == firstCount);
        }
    }
}

