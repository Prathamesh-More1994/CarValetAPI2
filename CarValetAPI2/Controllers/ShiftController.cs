using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Shifts
    [ApiController]
    [Route("Shift")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftApplication ShiftApplication;

        public ShiftController(IShiftApplication ShiftApplication)
        {
            this.ShiftApplication = ShiftApplication;
        }

        //Get /ShiftList
        [HttpGet]
        public Task<IEnumerable<Shift>> GetShiftList()
        {
            var Shifts = ShiftApplication.GetShiftsAsync();
            return Shifts;
        }

        //Get /Shift/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShiftById(string id)
        {
            var Shift = await ShiftApplication.GetShiftById(id);

            if (Shift is null)
            {
                return NotFound();
            }
            return Ok(Shift);
        }

        // POST /Shift
        [HttpPost]
        public async Task<ActionResult<Shift>> CreateShiftAsync(Shift Shift)
        {

            await ShiftApplication.CreateShiftAsync(Shift);
            return CreatedAtAction(nameof(GetShiftById), new { id = Shift.ShiftId }, new { Shift });
        }

        // PUT /Shift/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShiftAsync(string id, Shift Shift)
        {
            var existingShift = await ShiftApplication.GetShiftById(id);

            if (existingShift is null)
            {
                return NotFound();
            }
        //TODO: Fields to be added

            await ShiftApplication.UpdateShiftAsync(existingShift);

            return NoContent();
        }

        // DELETE /Shift/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShiftAsync(string id)
        {
            var existingShift = await ShiftApplication.GetShiftById(id);

            if (existingShift is null)
            {
                return NotFound();
            }

            await ShiftApplication.DeleteShiftAsync(id);

            return NoContent();
        }
    }
}