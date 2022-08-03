using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListQueryRepository : QueryRepository<ShopList>, IShopListQueryRepository
    {
        public ShopListQueryRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
