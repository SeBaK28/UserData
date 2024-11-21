using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PlaceOgBirthRepository : IPlaceOgBirthRepository
    {
        private readonly ApplicationDbContext _context;
        public PlaceOgBirthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PlaceOfBirth>> GetAllAsync()
        {
            return await _context.PlaceOfBirths.ToListAsync();
        }

        public async Task<PlaceOfBirth?> GetByIdAsync(int id)
        {
            return await _context.PlaceOfBirths.FindAsync(id);
        }
    }
}