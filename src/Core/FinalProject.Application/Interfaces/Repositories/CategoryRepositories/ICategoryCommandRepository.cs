using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities;


namespace FinalProject.Application.Interfaces.Repositories.CategoryRepositories
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {
    }
}
