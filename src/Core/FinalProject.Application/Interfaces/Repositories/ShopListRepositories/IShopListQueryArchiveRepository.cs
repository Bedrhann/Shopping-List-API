using FinalProject.Application.DTOs.ShopList;

namespace FinalProject.Application.Interfaces.Repositories.ShopListRepositories
{
    public interface IShopListQueryArchiveRepository
    {
        IQueryable<ShopListArchiveDto> GetAll();
    }
}
