using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(string id);
        Task<IEnumerable<Company>> GetCompanysAsync();
        Task<IEnumerable<Company>> GetCompaniesByLocationAsync(Location location);
        Task CreateCompanyAsync(Company company);
        Task CreateCompanyDemoAsync(CompanyDto company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(string id);
    }
}