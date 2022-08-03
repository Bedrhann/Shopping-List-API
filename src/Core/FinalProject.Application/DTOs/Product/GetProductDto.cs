using FinalProject.Domain.Entities.Common;
using FinalProject.Domain.Entities.Enums;

namespace FinalProject.Application.DTOs.Product
{
    public class GetProductDto : BaseEntity
    {
        [System.Text.Json.Serialization.JsonPropertyName("quantity")]
        public float Quantity { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("measurementType")]
        public MeasurementType MeasurementType { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("isPurchased")]
        public bool IsPurchased { get; set; }
    }
}
