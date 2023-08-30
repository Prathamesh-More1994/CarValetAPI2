using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IOwnerApplication
    {
        Task<Owner> GetOwnerById(string id);
        Task<IEnumerable<Owner>> GetOwnersAsync();
        Task<Owner?> GetOwnerFromList(Owner owner);
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(string id);
    }
}