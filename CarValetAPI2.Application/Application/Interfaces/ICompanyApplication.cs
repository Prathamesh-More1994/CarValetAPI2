using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface ICompanyApplication
    {
        Task<Company> GetCompanyById(string id);
        Task<IEnumerable<Company>> GetCompanysAsync();
        Task<IEnumerable<Company>> GetCompaniesByLocationAsync(Location location);
        Task<IEnumerable<Company>> GetCompaniesByNameAsync(string name);
        Task<Company> GetCompanyByOwner(Owner owner);
        Task CreateCompanyAsync(Company company);
        Task CreateCompanyDemoAsync(CompanyDto company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(string id);

    }
}