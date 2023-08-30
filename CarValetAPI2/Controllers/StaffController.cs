using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Helper;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Staffs
    [ApiController]
    [Route("staff")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffApplication staffApplication;

        public StaffController(IStaffApplication staffApplication)
        {
            this.staffApplication = staffApplication;
        }

        //Get /staffList
        [HttpGet]
        public Task<IEnumerable<Staff>> GetStaffList()
        {
            var staffs = staffApplication.GetStaffsAsync();
            return staffs;
        }

        //Get /staff/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(string id)
        {
            var staff = await staffApplication.GetStaffById(id);

            if (staff is null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [Route("companyStaff")]
        [HttpPost]
        public async Task<ActionResult<List<Staff>>> GetStaffByCompanyId(Object companyId)
        {
            var staffList = await staffApplication.GetStaffByCompanyId(companyId.ToString());
            return Ok(staffList);
        }

        // POST /staff
        [HttpPost]
        public async Task<ActionResult<Staff>> CreateStaffAsync(StaffDto staffDto)
        {
            var staff = Mapper.GetStaffFromDto(staffDto);
            await staffApplication.CreateStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaffById), new { id = staff.StaffId }, new { staff });
        }

        // PUT /staff/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaffAsync(string id, Staff staff)
        {
            var existingStaff = await staffApplication.GetStaffById(id);

            if (existingStaff is null)
            {
                return NotFound();
            }

            existingStaff.Email = staff.Email;
            existingStaff.Password = staff.Password;
            existingStaff.Shift = staff.Shift;
            // existingStaff.ShiftId = staff.ShiftId;

            await staffApplication.UpdateStaffAsync(existingStaff);

            return NoContent();
        }


        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Staff>> GetStaffFromList(Staff staff)
        {
            var staffValue = await staffApplication.GetStaffFromList(staff);

            if (staffValue is null)
            {
                return NotFound();
            }
            return Ok(staffValue);
        }

        // DELETE /staff/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaffAsync(string id)
        {
            var existingStaff = await staffApplication.GetStaffById(id);

            if (existingStaff is null)
            {
                return NotFound();
            }

            await staffApplication.DeleteStaffAsync(id);

            return NoContent();
        }
    }
}