using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Wallets
    [ApiController]
    [Route("wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletApplication walletApplication;

        public WalletController(IWalletApplication walletApplication)
        {
            this.walletApplication = walletApplication;
        }

        //Get /walletList
        [HttpGet]
        public Task<IEnumerable<Wallet>> GetWalletList()
        {
            var wallets = walletApplication.GetWalletsAsync();
            return wallets;
        }

        //Get /wallet/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWalletById(string id)
        {
            var wallet = await walletApplication.GetWalletById(id);

            if (wallet is null)
            {
                return NotFound();
            }
            return Ok(wallet);
        }

        // POST /wallet
        [HttpPost]
        public async Task<ActionResult<Wallet>> CreateWalletAsync(Wallet wallet)
        {

            await walletApplication.CreateWalletAsync(wallet);
            return CreatedAtAction(nameof(GetWalletById), new { id = wallet.WalletId }, new { wallet });
        }

        // PUT /wallet/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWalletAsync(string id, Wallet wallet)
        {
            var existingWallet = await walletApplication.GetWalletById(id);

            if (existingWallet is null)
            {
                return NotFound();
            }

            existingWallet.Amount = wallet.Amount;
            existingWallet.isActive = wallet.isActive;
            existingWallet.PaymentDetails = wallet.PaymentDetails;

            await walletApplication.UpdateWalletAsync(existingWallet);

            return NoContent();
        }

        // DELETE /wallet/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWalletAsync(string id)
        {
            var existingWallet = await walletApplication.GetWalletById(id);

            if (existingWallet is null)
            {
                return NotFound();
            }

            await walletApplication.DeleteWalletAsync(id);

            return NoContent();
        }
    }
}