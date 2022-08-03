using FinalProject.Application.Interfaces;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.Common;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Persistence.Contexts
{
    public class PostgreSqlDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options)
        {
        }
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var Datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in Datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreationDate = DateTime.UtcNow;

                if (data.State == EntityState.Modified)
                    data.Entity.UpdateDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
