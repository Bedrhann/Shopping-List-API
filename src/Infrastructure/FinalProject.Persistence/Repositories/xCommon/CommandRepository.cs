using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities.Common;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinalProject.Persistence.Repositories.Common
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly PostgreSqlDbContext _context;

        public CommandRepository(PostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entity = await Table.AddAsync(model);
            return entity.State == EntityState.Added;
        }

        public async Task<bool> AddMultipleAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entity = Table.Remove(model);
            return entity.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
            T model = await Table.FindAsync(Guid.Parse(id));
            return Remove(model);
        }

        public bool RemoveMultiple(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry entity = Table.Update(model);
            return entity.State == EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
