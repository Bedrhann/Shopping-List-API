using FinalProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
