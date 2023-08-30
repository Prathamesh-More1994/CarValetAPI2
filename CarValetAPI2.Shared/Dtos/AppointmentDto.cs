using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Shared.Dtos
{
    public class AppointmentDto
    {
        public Appointment? Appointment { get; set; }
        public string? CustomerName { get; set; }
    }
}