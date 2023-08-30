using Geolocation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Company : MongoEntity
    {
        public Company()
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

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class WorkingHour
    {
        public int Id { get; set; }
        public string? Day { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool? IsAvailable { get; set; }
    }

}