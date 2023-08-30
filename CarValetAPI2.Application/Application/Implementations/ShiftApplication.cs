using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class ShiftApplication : IShiftApplication
    {
        public readonly IShiftRepository ShiftRepository;

        public ShiftApplication(IShiftRepository ShiftRepository)
        {
            this.ShiftRepository = ShiftRepository;
        }
        public async Task CreateShiftAsync(Shift Shift)
        {
            await ShiftRepository.CreateShiftAsync(Shift);
        }

        public async Task DeleteShiftAsync(string id)
        {
            await ShiftRepository.DeleteShiftAsync(id);
        }

        public async Task<Shift> GetShiftById(string id)
        {
            return await ShiftRepository.GetShiftById(id);
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            return await ShiftRepository.GetShiftsAsync();
        }

        public async Task UpdateShiftAsync(Shift Shift)
        {
            await ShiftRepository.UpdateShiftAsync(Shift);
        }
    }
}