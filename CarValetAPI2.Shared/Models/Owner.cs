using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Owner : MongoEntity
    {
        public Owner()
        {
            OwnerId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        //public string CompanyId { get; set; }
    }
}