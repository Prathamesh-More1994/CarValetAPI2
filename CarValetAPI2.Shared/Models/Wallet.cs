using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Wallet
    {
        public Wallet()
        {
            WalletId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? WalletId { get; set; }
        public string? Amount { get; set; }
        public bool? isActive { get; set; }
        public string? PaymentDetails { get; set; }

    }
}