using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Staff
    {
        public Staff()
        {
            StaffId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? StaffId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? Expertise { get; set; }
        // public Company Company { get; set; }
        public List<Shift>? Shift { get; set; }
        public string? CompanyId { get; set; }

    }

    public class StaffDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }

        // public Company Company { get; set; }
        public List<ShiftDto>? Shift { get; set; }
        public string? Expertise { get; set; }
        public string? CompanyId { get; set; }
    }
}