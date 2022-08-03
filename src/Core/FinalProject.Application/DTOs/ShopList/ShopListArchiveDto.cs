using FinalProject.Domain.Entities.Common;

namespace FinalProject.Application.DTOs.ShopList
{
    public class ShopListArchiveDto : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public Guid AppUserId { get; set; }
    }
}
