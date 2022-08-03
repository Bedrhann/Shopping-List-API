using FinalProject.Domain.Entities.Common;
using FinalProject.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public bool IsPurchased { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
