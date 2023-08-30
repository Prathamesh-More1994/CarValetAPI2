using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class AppointmentApplication : IAppointmentApplication
    {
        public readonly IAppointmentRepository appointmentRepository;

        public AppointmentApplication(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await appointmentRepository.CreateAppointmentAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(string id)
        {
            await appointmentRepository.DeleteAppointmentAsync(id);
        }

        public async Task<Appointment> GetAppointmentById(string id)
        {
            return await appointmentRepository.GetAppointmentById(id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await appointmentRepository.GetAppointmentsAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await appointmentRepository.UpdateAppointmentAsync(appointment);
        }
    }
}