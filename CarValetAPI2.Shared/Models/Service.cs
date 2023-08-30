using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Service : MongoEntity
    {

        public Service()
        {
            ServiceId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ServiceId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public double? EstimatedTime { get; set; }
        public string? Description { get; set; }
    }
}