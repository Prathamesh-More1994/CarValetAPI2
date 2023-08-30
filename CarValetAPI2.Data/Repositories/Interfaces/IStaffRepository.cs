using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> GetStaffById(string id);
        Task<IEnumerable<Staff>> GetStaffsAsync();
        Task<List<Staff>> GetStaffByCompanyId(string companyId);
        Task CreateStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(string id);
    }
}