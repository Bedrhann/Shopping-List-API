using FinalProject.Application.DTOs.ShopList;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Persistence.Contexts
{
    public class MsSqlDbContext : DbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
        }
        public DbSet<ShopListArchiveDto> CompletedShopLists { get; set; }
        
    }
}
