using MongoDB.Bson.Serialization.Attributes;

namespace Prestadito.Investment.Domain.MainModule.Core
{
    public class AuditEntity : BaseEntity
    {
        [BsonElement("strCreateFinancing")]
        public string StrCreateFinancing { get; set; } = null!;
        [BsonElement("dteCreatedAt")]
        public DateTime DteCreatedAt { get; set; } = DateTime.UtcNow;
        [BsonElement("strUpdateFinancing")]
        public string StrUpdateFinancing { get; set; } = null!;
        [BsonElement("dteUpdatedAt")]
        public DateTime DteUpdatedAt { get; set; }
    }
}
