namespace CarValetAPI2.Shared.Dtos
{
    public class RequestObj
    {
        public UseObj? Useobj { get; set; }
        public List<WorkingHourObj>? WorkingHoursObj { get; set; }
        public List<ServiceObj>? ServiceObj { get; set; }
        public LocationObj? LocationObj { get; set; }
    }

    public class WorkingHourObj
    {
        public int Id { get; set; }
        public string? Day { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public bool? IsAvailable { get; set; }
    }


    public class UseObj
    {
        public string? Name { get; set; }
        public string? BusinessName { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
    }

    public class ServiceObj
    {
        public int EstimatedTime { get; set; }
        public int Price { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
    }

    public class LocationObj
    {
        public double Lat { get; set; }
        public double Long { get; set; }
    }

}