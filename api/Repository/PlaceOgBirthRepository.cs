using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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

        public async Task<bool> PlaceOfBirthEgzist(int id)
        {
            return await _context.PlaceOfBirths.AnyAsync(s => s.UserDataId == id);
        }
    }
}