using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Persistence.Repositories.ShopListRepositories
{
    public class ShopListQueryArchiveRepository : IShopListQueryArchiveRepository
    {
        private readonly MsSqlDbContext _context;
        public ShopListQueryArchiveRepository(MsSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<ShopListArchiveDto> Table => _context.Set<ShopListArchiveDto>();

        public IQueryable<ShopListArchiveDto> GetAll()
        {
            return Table;
        }
    }
}
