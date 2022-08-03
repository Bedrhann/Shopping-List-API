using FinalProject.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<Product> Products { get; set; }

        public Guid ShopListId { get; set; }
        [ForeignKey("ShopListId")]
        public ShopList ShopList { get; set; }
    }
}
