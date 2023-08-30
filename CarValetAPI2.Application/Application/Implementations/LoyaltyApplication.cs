using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class LoyaltyApplication : ILoyaltyApplication
    {
        public readonly ILoyaltyRepository loyaltyRepository;

        public LoyaltyApplication(ILoyaltyRepository loyaltyRepository)
        {
            this.loyaltyRepository = loyaltyRepository;
        }
        public async Task CreateLoyaltyAsync(Loyalty loyalty)
        {
            await loyaltyRepository.CreateLoyaltyAsync(loyalty);
        }

        public async Task DeleteLoyaltyAsync(string id)
        {
            await loyaltyRepository.DeleteLoyaltyAsync(id);
        }

        public async Task<Loyalty> GetLoyaltyById(string id)
        {
            return await loyaltyRepository.GetLoyaltyById(id);
        }

        public async Task<IEnumerable<Loyalty>> GetLoyaltysAsync()
        {
            return await loyaltyRepository.GetLoyaltysAsync();
        }

        public async Task UpdateLoyaltyAsync(Loyalty loyalty)
        {
            await loyaltyRepository.UpdateLoyaltyAsync(loyalty);
        }
    }
}