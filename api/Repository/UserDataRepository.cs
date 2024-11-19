using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.UserData;

namespace api.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly ApplicationDbContext _context;

        public UserDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserData> CreateAsync(UserData userData)
        {
            await _context.UserDatas.AddAsync(userData);
            await _context.SaveChangesAsync();

            return userData;
        }

        public async Task<UserData?> DeleteAsync(int id)
        {
            var stockModel = await _context.UserDatas.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _context.UserDatas.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<UserData>> GetAllAsync()
        {
            return await _context.UserDatas.ToListAsync();
        }

        public async Task<UserData?> GetByIdAsync(int id)
        {
            return await _context.UserDatas.FindAsync(id);
        }

        public async Task<UserData?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var exsistingModel = await _context.UserDatas.FirstOrDefaultAsync(x => x.Id == id);

            if (exsistingModel == null)
            {
                return null;
            }

            exsistingModel.Name = stockDto.Name;
            exsistingModel.SecondName = stockDto.SecondName;
            exsistingModel.Sex = stockDto.Sex;
            exsistingModel.DateOfBirth = stockDto.DateOfBirth;

            await _context.SaveChangesAsync();

            return exsistingModel;
        }
    }
}