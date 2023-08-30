using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class StaffApplication : IStaffApplication
    {
        public readonly IStaffRepository staffRepository;

        public StaffApplication(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }
        public async Task CreateStaffAsync(Staff staff)
        {
            await staffRepository.CreateStaffAsync(staff);
        }

        public async Task DeleteStaffAsync(string id)
        {
            await staffRepository.DeleteStaffAsync(id);
        }

        public async Task<List<Staff>> GetStaffByCompanyId(string companyId)
        {
            return await staffRepository.GetStaffByCompanyId(companyId);
        }

        public async Task<Staff> GetStaffById(string id)
        {
            return await staffRepository.GetStaffById(id);
        }

        public async Task<Staff?> GetStaffFromList(Staff staff)
        {
            var staffList = await staffRepository.GetStaffsAsync();
            return staffList?.Where(x => x.Email.Equals(staff.Email)
            && x.Password.Equals(staff.Password)).FirstOrDefault();
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync()
        {
            return await staffRepository.GetStaffsAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            await staffRepository.UpdateStaffAsync(staff);
        }
    }
}