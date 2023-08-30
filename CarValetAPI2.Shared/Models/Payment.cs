using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    public class Payment
    {
        public Payment()
        {
            PaymentId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? PaymentId { get; set; }
        public long Amount { get; set; }
        public string? ProductName { get; set; }
        public List<Dictionary<string, string>>? Metadata { get; set; }
        public string? CompanyId { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}