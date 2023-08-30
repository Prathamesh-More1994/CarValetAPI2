using CarValetAPI2.Shared.Models;
using Geolocation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
            CompanyId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CompanyId { get; set; }
        public Owner? Owner { get; set; }
        public List<Service>? Service { get; set; }
        public string? Address { get; set; }
        public string? CompanyName { get; set; }
        public DateTime ServiceDay { get; set; }

        [BsonSerializer(typeof(CustomSerializer))]
        public Coordinate Location { get; set; }

        public List<WorkingHour>? WorkingHours { get; set; }
        public List<Staff>? Staffs { get; set; }
    }
}