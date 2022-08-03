using FinalProject.Application.DTOs.ShopList;

namespace FinalProject.Application.Interfaces.Repositories.ShopListRepositories
{
    public interface IShopListCommandArchiveRepository
    {
        Task SendCompletedShopList(ShopListArchiveDto model);
        Task SaveAsync();
    }
}

