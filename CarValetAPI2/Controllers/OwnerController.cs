using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Owners
    [ApiController]
    [Route("owner")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerApplication ownerApplication;

        public OwnerController(IOwnerApplication ownerApplication)
        {
            this.ownerApplication = ownerApplication;
        }

        //Get /ownerList
        [HttpGet]
        public Task<IEnumerable<Owner>> GetOwnerList()
        {
            var owners = ownerApplication.GetOwnersAsync();
            return owners;
        }

        //Get /owner/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwnerById(string id)
        {
            var owner = await ownerApplication.GetOwnerById(id);

            if (owner is null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        // POST /owner
        [HttpPost]
        public async Task<ActionResult<Owner>> CreateOwnerAsync(Owner owner)
        {

            await ownerApplication.CreateOwnerAsync(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.OwnerId }, new { owner });
        }


        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<Owner>> GetOwnerFromList(Owner owner)
        {
            var ownerValue = await ownerApplication.GetOwnerFromList(owner);

            if (ownerValue is null)
            {
                return NotFound();
            }
            return Ok(ownerValue);
        }

        // PUT /owner/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOwnerAsync(string id, Owner owner)
        {
            var existingOwner = await ownerApplication.GetOwnerById(id);

            if (existingOwner is null)
            {
                return NotFound();
            }

            //existingOwner.CompanyId = owner.CompanyId;
            existingOwner.Email = owner.Email;
            existingOwner.Mobile = owner.Mobile;
            existingOwner.Name = owner.Name;
            existingOwner.Password = owner.Password;

            await ownerApplication.UpdateOwnerAsync(existingOwner);

            return NoContent();
        }

        // DELETE /owner/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOwnerAsync(string id)
        {
            var existingOwner = await ownerApplication.GetOwnerById(id);

            if (existingOwner is null)
            {
                return NotFound();
            }

            await ownerApplication.DeleteOwnerAsync(id);

            return NoContent();
        }
    }
}