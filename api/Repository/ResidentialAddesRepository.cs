using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ResidentialAddres;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ResidentialAddesRepository : IResidentialAddresRepository
    {
        private readonly ApplicationDbContext _context;

        public ResidentialAddesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResidentialAddres> CreateAddressAsync(ResidentialAddres residentialAddres)
        {
            await _context.ResidentialAddress.AddAsync(residentialAddres);
            await _context.SaveChangesAsync();
            return residentialAddres;
        }

        public async Task<List<ResidentialAddres>> GetAllAsync()
        {
            return await _context.ResidentialAddress.ToListAsync();
        }
        public async Task<ResidentialAddres?> UpdateAddresAsync(int id, UpdateResidentialAddresRequestDto updateResident)
        {
            var address = await _context.ResidentialAddress.FirstOrDefaultAsync(c => c.Id == id);
            if (address == null)
            {
                return null;
            }

            address.City = updateResident.City;
            address.Country = updateResident.Country;
            address.Street = updateResident.Street;

            await _context.SaveChangesAsync();

            return address;
        }
        public async Task<ResidentialAddres?> GetByIdAsync(int id)
        {
            return await _context.ResidentialAddress.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> AddressExist(int id)
        {
            return await _context.ResidentialAddress.AnyAsync(a => a.UserDataId == id);
        }
    }
}