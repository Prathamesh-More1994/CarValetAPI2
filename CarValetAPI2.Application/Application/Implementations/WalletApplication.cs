using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class WalletApplication : IWalletApplication
    {
        public readonly IWalletRepository walletRepository;

        public WalletApplication(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }
        public async Task CreateWalletAsync(Wallet wallet)
        {
            await walletRepository.CreateWalletAsync(wallet);
        }

        public async Task DeleteWalletAsync(string id)
        {
            await walletRepository.DeleteWalletAsync(id);
        }

        public async Task<Wallet> GetWalletById(string id)
        {
            return await walletRepository.GetWalletById(id);
        }

        public async Task<IEnumerable<Wallet>> GetWalletsAsync()
        {
            return await walletRepository.GetWalletsAsync();
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            await walletRepository.UpdateWalletAsync(wallet);
        }
    }
}