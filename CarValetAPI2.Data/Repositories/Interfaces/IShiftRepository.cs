using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IShiftRepository
    {
        Task<Shift> GetShiftById(string id);
        Task<IEnumerable<Shift>> GetShiftsAsync();
        Task CreateShiftAsync(Shift Shift);
        Task UpdateShiftAsync(Shift Shift);
        Task DeleteShiftAsync(string id);
    }
}