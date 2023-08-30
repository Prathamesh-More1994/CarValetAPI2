using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletById(string id);
        Task<IEnumerable<Wallet>> GetWalletsAsync();
        Task CreateWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(string id);
    }
}