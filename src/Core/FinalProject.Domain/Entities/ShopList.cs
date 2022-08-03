using FinalProject.Domain.Entities.Common;
using FinalProject.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Entities
{
    public class ShopList : BaseEntity
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
