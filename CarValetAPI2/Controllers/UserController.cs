using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Users
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication userApplication;

        public UserController(IUserApplication userApplication)
        {
            this.userApplication = userApplication;
        }

        //Get /userList
        [HttpGet]
        public Task<IEnumerable<User>> GetUserList()
        {
            var users = userApplication.GetUsersAsync();
            return users;
        }

        //Get /user/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await userApplication.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("staff")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetStaffAppointmentById(string staffid)
        {
            var appointments = await userApplication.GetStaffAppointmentById(staffid);

            return Ok(appointments);
        }

        [HttpPost]
        [Route("appointment")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetCompanyAppointment(Company company)
        {
            var appointments = await userApplication.GetCompanyAppointments(company);

            return Ok(appointments);
        }

        //Post /user/update

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Appointment>> UpdateStaffAppointment(Appointment appointment)
        {
            var appointmentValue = await userApplication.UpdateStaffAppointment(appointment);

            return Ok(appointmentValue);
        }

        [HttpPost]
        [Route("rate")]
        public async Task<ActionResult<Appointment>> RateAppointment(Appointment appointment)
        {
            var appointmentValue = await userApplication.RateAppointment(appointment);

            return Ok(appointmentValue);
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<ActionResult<Appointment>> CancelStaffAppointment(Appointment appointment)
        {
            var appointmentValue = await userApplication.CancelStaffAppointment(appointment);

            return Ok(appointmentValue);
        }

        // POST /user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            await userApplication.CreateUserAsync(user);
            // System.Console.WriteLine("nameofurl: " + nameof(GetUserById));
            // System.Console.WriteLine("nameofurl:" + new { id = user.Id });
            // System.Console.WriteLine("nameofurl:" + CreatedAtAction(nameof(GetUserById), new { id = user.Id }, new { user }));
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, new { user });
        }

        // POST /user/updateUser
        [Route("updateUser")]
        [HttpPost]
        public async Task<ActionResult> UpdateUserAsync(User user)
        {
            var existingUser = await userApplication.GetUserById(user?.UserId);

            if (existingUser is null)
            {
                return NotFound();
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Mobile = user.Mobile;
            existingUser.Appointments = user.Appointments;
            existingUser.CreatedDate = user.CreatedDate;
            existingUser.Mobile = user.Mobile;
            existingUser.Password = user.Password;
            existingUser.UserId = user.UserId;

            await userApplication.UpdateUserAsync(existingUser);

            return Ok(new { message = "Success" });
        }

        //Get /user/id
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> GetUserFromList(User user)
        {
            var userValue = await userApplication.GetUserFromList(user);

            if (userValue is null)
            {
                return NotFound();
            }
            return Ok(userValue);
        }

        // DELETE /user/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(string id)
        {
            var existingUser = await userApplication.GetUserById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            await userApplication.DeleteUserAsync(id);

            return NoContent();
        }
    }
}