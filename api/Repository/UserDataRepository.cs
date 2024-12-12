using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.UserData;
using Mysqlx;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
            return await _context.UserDatas.Include(c => c.PlaceOfBirths).ToListAsync();
        }
        /*
                public async Task<UserData?> GetByIdAsync(int id)
                {
                    return await _context.UserDatas.Include(c => c.PlaceOfBirths).FirstOrDefaultAsync(i => i.Id == id);
                }*/

        public async Task<UserData?> GetByNameAsync(string Name)
        {
            return await _context.UserDatas.FirstOrDefaultAsync(n => n.Name == Name);
        }

        public async Task<UserData?> UpdateAsync(int id, UpdateUserDataRequestDto stockDto)
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