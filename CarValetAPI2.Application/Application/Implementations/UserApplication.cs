using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class UserApplication : IUserApplication
    {
        public readonly IUserRepository userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Appointment> CancelStaffAppointment(Appointment appointment)
        {
            var userList = await userRepository.GetUsersAsync();
            var appointmentValue = new Appointment();
            userList.ToList().ForEach(z => z.Appointments.ForEach(a =>
         {
             if (a.AppointmentId.Equals(appointment.AppointmentId))
             {
                 a.IsCancelled = true;
                 appointmentValue = a;
                 userRepository.UpdateUserAsync(z);
             }
         }));
            return appointmentValue;
        }

        public async Task CreateUserAsync(User user)
        {
            await userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<AppointmentDto>> GetCompanyAppointments(Company company)
        {
            var userList = await userRepository.GetUsersAsync();
            var appointmentList = new List<Appointment>();
            var responseList = new List<AppointmentDto>();


            userList.ToList().ForEach(z => z.Appointments.ForEach(a =>
                     {
                         if (a.Staff.CompanyId.Equals(company.CompanyId))
                         {
                             var response = new AppointmentDto
                             {
                                 Appointment = a,
                                 CustomerName = z.Name

                             };
                             responseList.Add(response);
                         }
                     }));


            // var appointments = userList.Where(a => a.Appointments != null).Select(c =>
            // {
            //     return new AppointmentDto
            //     {
            //         Appointments = c.Appointments.Where(k => k.Staff.CompanyId.Equals(company.CompanyId)).ToList(),
            //         CustomerName = c.Name
            //     };
            // });


            return responseList;
        }

        public async Task<IEnumerable<Appointment>?> GetStaffAppointmentById(string id)
        {
            var userList = await userRepository.GetUsersAsync();
            var appointmentList = new List<Appointment>();
            var appointments = userList.Where(a => a.Appointments != null)
            .SelectMany(x => x.Appointments)
            .Where(z => z.Staff.StaffId.Equals(id));
            return appointments;
        }

        public async Task<User> GetUserById(string id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<User> GetUserFromList(User user)
        {
            var userList = await userRepository.GetUsersAsync();
            return userList?.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await userRepository.GetUsersAsync();
        }

        public async Task<Appointment> RateAppointment(Appointment appointment)
        {
            var userList = await userRepository.GetUsersAsync();
            var appointmentValue = new Appointment();
            userList.ToList().ForEach(z => z.Appointments.ForEach(a =>
         {
             if (a.AppointmentId.Equals(appointment.AppointmentId))
             {
                 a.Rating = appointment.Rating;
                 a.Comment = appointment.Comment;
                 appointmentValue = a;
                 userRepository.UpdateUserAsync(z);
             }
         }));
            return appointmentValue;
        }

        public async Task<Appointment> UpdateStaffAppointment(Appointment appointment)
        {
            var userList = await userRepository.GetUsersAsync();
            var appointmentValue = new Appointment();
            userList.ToList().ForEach(z => z.Appointments.ForEach(a =>
         {
             if (a.AppointmentId.Equals(appointment.AppointmentId))
             {
                 a.IsCompleted = true;
                 appointmentValue = a;
                 userRepository.UpdateUserAsync(z);
             }
         }));
            return appointmentValue;
        }

        public async Task UpdateUserAsync(User user)
        {
            await userRepository.UpdateUserAsync(user);
        }
    }
}