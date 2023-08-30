using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetAppointmentById(string id);
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task CreateAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(string id);
    }
}