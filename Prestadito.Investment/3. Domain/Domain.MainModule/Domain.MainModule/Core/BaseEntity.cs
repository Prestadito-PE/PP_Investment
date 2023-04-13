using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Prestadito.Investment.Domain.MainModule.Core
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("blnActive")]
        public bool BlnActive { get; set; } = true;
    }
}
