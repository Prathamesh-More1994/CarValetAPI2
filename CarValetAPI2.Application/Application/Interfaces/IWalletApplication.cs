using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IWalletApplication
    {
        Task<Wallet> GetWalletById(string id);
        Task<IEnumerable<Wallet>> GetWalletsAsync();
        Task CreateWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(string id);
    }
}