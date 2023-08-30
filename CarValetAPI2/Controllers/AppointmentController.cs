using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Appointments
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentApplication appointmentApplication;

        public AppointmentController(IAppointmentApplication appointmentApplication)
        {
            this.appointmentApplication = appointmentApplication;
        }

        //Get /appointmentList
        [HttpGet]
        public Task<IEnumerable<Appointment>> GetAppointmentList()
        {
            var appointments = appointmentApplication.GetAppointmentsAsync();
            return appointments;
        }

        //Get /appointment/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(string id)
        {
            var appointment = await appointmentApplication.GetAppointmentById(id);

            if (appointment is null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        // POST /appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointmentAsync(Appointment appointment)
        {

            await appointmentApplication.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, new { appointment });
        }


        // PUT /appointment/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointmentAsync(string id, Appointment appointment)
        {
            var existingAppointment = await appointmentApplication.GetAppointmentById(id);

            if (existingAppointment is null)
            {
                return NotFound();
            }

            existingAppointment.TimeSlot = appointment.TimeSlot;
            existingAppointment.StartTime = appointment.StartTime;
            existingAppointment.EndTime = appointment.EndTime;
            existingAppointment.Amount = appointment.Amount;
            existingAppointment.Service = appointment.Service;

            await appointmentApplication.UpdateAppointmentAsync(existingAppointment);

            return NoContent();
        }

        // DELETE /appointment/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointmentAsync(string id)
        {
            var existingAppointment = await appointmentApplication.GetAppointmentById(id);

            if (existingAppointment is null)
            {
                return NotFound();
            }

            await appointmentApplication.DeleteAppointmentAsync(id);

            return NoContent();
        }
    }
}