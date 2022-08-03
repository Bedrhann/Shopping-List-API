
namespace FinalProject.Domain.Entities.Common
{
    public class BaseEntity
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Guid Id { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("updateDate")]
        public DateTime UpdateDate { get; set; }
    }
}
