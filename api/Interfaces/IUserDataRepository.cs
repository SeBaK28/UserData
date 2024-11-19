using api.Dtos.UserData;
using api.Models;

namespace api.Interfaces
{
    public interface IUserDataRepository
    {
        Task<List<UserData>> GetAllAsync();
        Task<UserData?> GetByIdAsync(int id);
        Task<UserData> CreateAsync(UserData userData);
        Task<UserData?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<UserData?> DeleteAsync(int id);
    }
}