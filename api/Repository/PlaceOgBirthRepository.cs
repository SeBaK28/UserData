using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.PlaceOfBirth;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Repository
{
    public class PlaceOgBirthRepository : IPlaceOgBirthRepository
    {
        private readonly ApplicationDbContext _context;
        public PlaceOgBirthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PlaceOfBirth> CreateAsync(PlaceOfBirth placeOfBirth)
        {
            await _context.PlaceOfBirths.AddAsync(placeOfBirth);
            await _context.SaveChangesAsync();
            return placeOfBirth;
        }

        public async Task<List<PlaceOfBirth>> GetAllAsync()
        {
            return await _context.PlaceOfBirths.ToListAsync();
        }

        public async Task<PlaceOfBirth?> GetByIdAsync(int id)
        {
            return await _context.PlaceOfBirths.FindAsync(id);
        }

        public async Task<bool> PlaceOfBirthExist(int id)
        {
            return await _context.PlaceOfBirths.AnyAsync(s => s.UserDataId == id);
        }

        public async Task<PlaceOfBirth?> UpdateAsync(int userId, UpdatePlaceOfBirthRequestDto placeOfBirth)
        {
            var existModel = await _context.PlaceOfBirths.FirstOrDefaultAsync(x => x.UserDataId == userId);

            if (existModel == null)
            {
                return null;
            }

            existModel.City = placeOfBirth.City;
            existModel.Country = placeOfBirth.Country;
            existModel.Street = placeOfBirth.Street;
            existModel.HouseNumber = placeOfBirth.HouseNumber;

            await _context.SaveChangesAsync();

            return existModel;
        }
    }
}