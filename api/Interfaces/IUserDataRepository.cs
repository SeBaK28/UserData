using api.Dtos.UserData;
using api.Models;

namespace api.Interfaces
{
    public interface IUserDataRepository
    {
        Task<List<UserData>> GetAllAsync();
        Task<UserData?> GetByIdAsync(int id);
        Task<UserData> CreateAsync(UserData userData);
        Task<UserData?> UpdateAsync(int id, UpdateUserDataRequestDto stockDto);
        Task<UserData?> DeleteAsync(int id);
        //Task<UserData?> GetByNameAsync(string Name);
    }
}