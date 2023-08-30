using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarValetAPI2.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Appointment
    {
        public Appointment()
        {
            AppointmentId = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AppointmentId { get; set; }
        public Service? Service { get; set; }
        public int? TimeSlot { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Amount { get; set; }
        public Staff? Staff { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}