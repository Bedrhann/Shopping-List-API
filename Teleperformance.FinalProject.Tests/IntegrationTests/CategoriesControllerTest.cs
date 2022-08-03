using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Application.DTOs.Category;
using System.Text.Json;
using System.Text;
using Xunit;

namespace Teleperformance.FinalProject.Tests.IntegrationTests
{
    public class CategoriesControllerTest : IClassFixture<FakeApplication>
    {

        private readonly HttpClient _httpClient;
        public CategoriesControllerTest(FakeApplication factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async void ProductCrudProcess()
        {
            //GET****************
            GetAllCategoryByShopListQueryRequest RequestGet = new GetAllCategoryByShopListQueryRequest()
            {
                ShopListId = Guid.Parse("078cc72b-48df-402d-99cb-5339467f923c")
            };
            HttpResponseMessage responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            string contentGet = await responseGet.Content.ReadAsStringAsync();
            List<GetCategoryDto> commentGet = JsonSerializer.Deserialize<List<GetCategoryDto>>(contentGet);
            Assert.NotNull(commentGet);
            int firstCount = commentGet.Count();

            //CREATE****************
            CreateCategoryCommandRequest createRequest = new CreateCategoryCommandRequest()
            {
                Name = "asdf",
                ShopListId = RequestGet.ShopListId
            };
            var bodyCreate = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseCreate = await _httpClient.PostAsync("/api/categories", bodyCreate);
            responseCreate.EnsureSuccessStatusCode();
            string contentCreate = await responseCreate.Content.ReadAsStringAsync();
            CreateCategoryCommandResponse commentCreate = JsonSerializer.Deserialize<CreateCategoryCommandResponse>(contentCreate);
            Assert.NotNull(commentCreate);
            Assert.NotNull(commentCreate.Message);
            Assert.NotNull(commentCreate.NewCategoryId);
            Assert.True(commentCreate.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<List<GetCategoryDto>>(contentGet);
            Assert.NotNull(commentGet);
            int afterCreationCount = commentGet.Count();
            Assert.True((afterCreationCount - 1) == firstCount);

            //GETBYID**************
            HttpResponseMessage responseGetById = await _httpClient.GetAsync($"/api/categories/{commentCreate.NewCategoryId}");
            responseGetById.EnsureSuccessStatusCode();
            string contentGetById = await responseGetById.Content.ReadAsStringAsync();
            GetCategoryDto commentGetById = JsonSerializer.Deserialize<GetCategoryDto>(contentGetById);
            Assert.NotNull(commentGetById);

            //UPDATE****************
            UpdateCategoryCommandRequest updateRequest = new UpdateCategoryCommandRequest()
            {
                Id = commentCreate.NewCategoryId,
                Name = "UpdatedTestName"
            };
            var bodyUpdate = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseUpdate = await _httpClient.PutAsync("/api/categories", bodyUpdate);
            responseUpdate.EnsureSuccessStatusCode();
            string contentUpdate = await responseUpdate.Content.ReadAsStringAsync();
            BaseResponse commentUpdate = JsonSerializer.Deserialize<BaseResponse>(contentUpdate);
            Assert.NotNull(commentUpdate);
            Assert.NotNull(commentUpdate.Message);
            Assert.True(commentUpdate.Success);

            //DELETE****************
            HttpResponseMessage responseDelete = await _httpClient.DeleteAsync($"/api/categories/{commentCreate.NewCategoryId}");
            responseDelete.EnsureSuccessStatusCode();
            string contentDelete = await responseDelete.Content.ReadAsStringAsync();
            BaseResponse commentDelete = JsonSerializer.Deserialize<BaseResponse>(contentDelete);
            Assert.NotNull(commentDelete);
            Assert.NotNull(commentDelete.Message);
            Assert.True(commentDelete.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/categories?ShopListId={RequestGet.ShopListId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<List<GetCategoryDto>>(contentGet);
            Assert.NotNull(commentGet);
            int lastCount = commentGet.Count();

            Assert.True(lastCount == firstCount);
        }
    }
}
