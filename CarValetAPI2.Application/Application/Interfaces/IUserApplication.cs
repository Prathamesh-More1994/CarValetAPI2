using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<User> GetUserById(string id);
        Task<IEnumerable<Appointment>> GetStaffAppointmentById(string id);
        Task<IEnumerable<AppointmentDto>> GetCompanyAppointments(Company company);
        Task<Appointment> CancelStaffAppointment(Appointment appointment);

        Task<Appointment> UpdateStaffAppointment(Appointment appointment);
        Task<Appointment> RateAppointment(Appointment appointment);

        Task<User> GetUserFromList(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string id);
    }
}