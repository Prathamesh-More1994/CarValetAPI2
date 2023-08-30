using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;
using Geolocation;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class CompanyApplication : ICompanyApplication
    {
        public readonly ICompanyRepository companyRepository;

        public CompanyApplication(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            await companyRepository.CreateCompanyAsync(company);
        }

        public async Task CreateCompanyDemoAsync(CompanyDto company)
        {
            await companyRepository.CreateCompanyDemoAsync(company);
        }

        public async Task DeleteCompanyAsync(string id)
        {
            await companyRepository.DeleteCompanyAsync(id);
        }

        public async Task<Company> GetCompanyById(string id)
        {
            return await companyRepository.GetCompanyById(id);
        }

        public async Task<IEnumerable<Company>> GetCompanysAsync()
        {
            var companies = await companyRepository.GetCompanysAsync();
            return companies;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByLocationAsync(Location location)
        {
            var companies = await companyRepository.GetCompaniesByLocationAsync(location);

            var coord = new Coordinate(location.Latitude, location.Longitude);
            return companies.OrderBy(x => GeoCalculator.GetDistance(coord, x.Location));
        }


        public async Task UpdateCompanyAsync(Company company)
        {
            await companyRepository.UpdateCompanyAsync(company);
        }

        public async Task<IEnumerable<Company>> GetCompaniesByNameAsync(string name)
        {
            var companies = await companyRepository.GetCompanysAsync();
            return companies.Where(x => x.CompanyName != null && x.CompanyName.Equals(name));
        }

        public async Task<Company> GetCompanyByOwner(Owner owner)
        {
            var companies = await companyRepository.GetCompanysAsync();
            var companies2 = companies.Where(x => x.Owner.OwnerId.Equals(owner.OwnerId)).FirstOrDefault();
            return companies2;
        }
    }
}