using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Loyaltys
    [ApiController]
    [Route("loyalty")]
    public class LoyaltyController : ControllerBase
    {
        private readonly ILoyaltyApplication loyaltyApplication;

        public LoyaltyController(ILoyaltyApplication loyaltyApplication)
        {
            this.loyaltyApplication = loyaltyApplication;
        }

        //Get /loyaltyList
        [HttpGet]
        public Task<IEnumerable<Loyalty>> GetLoyaltyList()
        {
            var loyaltys = loyaltyApplication.GetLoyaltysAsync();
            return loyaltys;
        }

        //Get /loyalty/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Loyalty>> GetLoyaltyById(string id)
        {
            var loyalty = await loyaltyApplication.GetLoyaltyById(id);

            if (loyalty is null)
            {
                return NotFound();
            }
            return Ok(loyalty);
        }

        // POST /loyalty
        [HttpPost]
        public async Task<ActionResult<Loyalty>> CreateLoyaltyAsync(Loyalty loyalty)
        {

            await loyaltyApplication.CreateLoyaltyAsync(loyalty);
            return CreatedAtAction(nameof(GetLoyaltyById), new { id = loyalty.LoyaltyId }, new { loyalty });
        }

        // PUT /loyalty/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLoyaltyAsync(string id, Loyalty loyalty)
        {
            var existingLoyalty = await loyaltyApplication.GetLoyaltyById(id);

            if (existingLoyalty is null)
            {
                return NotFound();
            }

            existingLoyalty.LoyaltyPoint = loyalty.LoyaltyPoint;
            existingLoyalty.isActive = loyalty.isActive;
            
            await loyaltyApplication.UpdateLoyaltyAsync(existingLoyalty);

            return NoContent();
        }

        // DELETE /loyalty/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoyaltyAsync(string id)
        {
            var existingLoyalty = await loyaltyApplication.GetLoyaltyById(id);

            if (existingLoyalty is null)
            {
                return NotFound();
            }

            await loyaltyApplication.DeleteLoyaltyAsync(id);

            return NoContent();
        }
    }
}