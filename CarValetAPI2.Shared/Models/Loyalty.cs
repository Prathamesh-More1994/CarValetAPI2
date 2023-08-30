using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Loyalty
    {
        public Loyalty()
        {
            LoyaltyId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? LoyaltyId { get; set; }
        public string? LoyaltyPoint { get; set; }
        public bool isActive { get; set; }
    }
}