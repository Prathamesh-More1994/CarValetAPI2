using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class OwnerApplication : IOwnerApplication
    {
        public readonly IOwnerRepository ownerRepository;

        public OwnerApplication(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }
        public async Task CreateOwnerAsync(Owner owner)
        {
            await ownerRepository.CreateOwnerAsync(owner);
        }

        public async Task DeleteOwnerAsync(string id)
        {
            await ownerRepository.DeleteOwnerAsync(id);
        }

        public async Task<Owner> GetOwnerById(string id)
        {
            return await ownerRepository.GetOwnerById(id);
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync()
        {
            return await ownerRepository.GetOwnersAsync();
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            await ownerRepository.UpdateOwnerAsync(owner);
        }

        public async Task<Owner?> GetOwnerFromList(Owner owner)
        {
            var companyList = await ownerRepository.GetOwnersAsync();
            return companyList?.Where(x => x.Email.Equals(owner.Email)
            && x.Password.Equals(owner.Password)).FirstOrDefault();
        }
    }
}