using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.UserData;
using Mysqlx;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using api.Helpers;

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

        public async Task<List<UserData>> GetAllAsync(QueryObject query)
        {
            var stock = _context.UserDatas.Include(c => c.PlaceOfBirths).Include(d => d.ResidentialAddresProp).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                stock = stock.Where(s => s.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SecondName))
            {
                stock = stock.Where(s => s.SecondName.Contains(query.SecondName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("SecoundName", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.IsDescending ? stock.OrderByDescending(s => s.SecondName) : stock.OrderBy(s => s.SecondName);
                }
            }

            return await stock.ToListAsync();

        }

        public async Task<UserData?> GetByIdAsync(int id)
        {
            return await _context.UserDatas.Include(c => c.PlaceOfBirths).Include(d => d.ResidentialAddresProp).FirstOrDefaultAsync(i => i.Id == id);
        }

        // public async Task<UserData?> GetByNameAsync(string Name)
        // {
        //     return await _context.UserDatas.FirstOrDefaultAsync(n => n.Name == Name);
        // }

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