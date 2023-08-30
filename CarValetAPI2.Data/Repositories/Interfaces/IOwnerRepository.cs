using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> GetOwnerById(string id);
        Task<IEnumerable<Owner>> GetOwnersAsync();
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(string id);
    }
}