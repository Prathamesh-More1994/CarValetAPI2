using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IAppointmentApplication
    {
        Task<Appointment> GetAppointmentById(string id);
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(string id);
    }
}