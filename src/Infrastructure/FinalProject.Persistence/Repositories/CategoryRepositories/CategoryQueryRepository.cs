using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;


namespace FinalProject.Persistence.Repositories.CategoryRepositories
{
    public class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
