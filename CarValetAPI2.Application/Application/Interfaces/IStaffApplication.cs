using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IStaffApplication
    {
        Task<Staff> GetStaffById(string id);
        Task<IEnumerable<Staff>> GetStaffsAsync();
        Task<List<Staff>> GetStaffByCompanyId(string companyId);
        Task<Staff> GetStaffFromList(Staff staff);
        Task CreateStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(string id);
    }
}