using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public User()
        {
            UserId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public Wallet? Wallet { get; set; }
        public Loyalty? Loyalty { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}