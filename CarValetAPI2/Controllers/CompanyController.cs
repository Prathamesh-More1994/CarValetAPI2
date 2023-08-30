using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Helper;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarValetAPI2.Controller
{
    //Get Companys
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyApplication companyApplication;

        public CompanyController(ICompanyApplication companyApplication)
        {
            this.companyApplication = companyApplication;
        }

        //Get /companyList
        [HttpGet]
        public Task<IEnumerable<Company>> GetCompanyList()
        {
            var companys = companyApplication.GetCompanysAsync();
            return companys;
        }

        //Post /company/location
        [Route("location")]
        [HttpPost]
        public Task<IEnumerable<Company>> GetCompaniesByLocation(Location location)
        {
            var companys = companyApplication.GetCompaniesByLocationAsync(location);
            return companys;
        }


        [Route("search")]
        [HttpPost]
        public Task<IEnumerable<Company>> GetCompaniesByName(Object searchText)
        {
            var companies = companyApplication.GetCompaniesByNameAsync(searchText?.ToString());
            return companies;
        }

        [Route("staff")]
        [HttpPost]
        public async Task<ActionResult<Company>> GetCompanyByOwner(Owner owner)
        {
            var company = await companyApplication.GetCompanyByOwner(owner);
            if (company is null)
            {
                return NotFound();
            }
            return Ok(company);
        }



        //Get /company/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanyById(string id)
        {
            var company = await companyApplication.GetCompanyById(id);

            if (company is null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST /company
        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompanyAsync(Company company)
        {
            await companyApplication.CreateCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, new { company });
        }

        [Route("createCompany")]
        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompanyDemoAsync(RequestObj requestObj)
        {
            var company = Mapper.GetCompanyDtoFromRequest(requestObj);
            await companyApplication.CreateCompanyDemoAsync(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, new { company });
        }

        // PUT /company/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompanyAsync(string id, Company company)
        {
            var existingCompany = await companyApplication.GetCompanyById(id);

            if (existingCompany is null)
            {
                return NotFound();
            }

            existingCompany.Address = company.Address;
            existingCompany.Service = company.Service;
            existingCompany.CompanyName = company.CompanyName;
            existingCompany.ServiceDay = company.ServiceDay;
            existingCompany.Owner = company.Owner;


            await companyApplication.UpdateCompanyAsync(existingCompany);

            return NoContent();
        }

        // DELETE /company/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompanyAsync(string id)
        {
            var existingCompany = await companyApplication.GetCompanyById(id);

            if (existingCompany is null)
            {
                return NotFound();
            }

            await companyApplication.DeleteCompanyAsync(id);

            return NoContent();
        }
    }
}