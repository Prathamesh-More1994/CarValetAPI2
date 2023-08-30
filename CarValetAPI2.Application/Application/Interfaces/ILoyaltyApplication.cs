using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface ILoyaltyApplication
    {
        Task<Loyalty> GetLoyaltyById(string id);
        Task<IEnumerable<Loyalty>> GetLoyaltysAsync();
        Task CreateLoyaltyAsync(Loyalty loyalty);
        Task UpdateLoyaltyAsync(Loyalty loyalty);
        Task DeleteLoyaltyAsync(string id);
    }
}