using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;


namespace FinalProject.Persistence.Repositories.ProductRepositories
{
    public class ProductQueryRepository : QueryRepository<Product>, IProductQueryRepository
    {
        public ProductQueryRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
