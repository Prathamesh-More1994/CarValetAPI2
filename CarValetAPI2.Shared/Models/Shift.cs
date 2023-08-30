using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Shift
    {
        public Shift()
        {
            ShiftId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ShiftId { get; set; }
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class ShiftDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool IsAvailable { get; set; }
    }
}