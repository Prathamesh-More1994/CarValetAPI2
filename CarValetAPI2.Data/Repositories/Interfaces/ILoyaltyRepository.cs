using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface ILoyaltyRepository
    {
        Task<Loyalty> GetLoyaltyById(string id);
        Task<IEnumerable<Loyalty>> GetLoyaltysAsync();
        Task CreateLoyaltyAsync(Loyalty loyalty);
        Task UpdateLoyaltyAsync(Loyalty loyalty);
        Task DeleteLoyaltyAsync(string id);
    }
}