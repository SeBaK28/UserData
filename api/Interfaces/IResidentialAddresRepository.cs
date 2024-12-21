using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ResidentialAddres;
using api.Models;

namespace api.Interfaces
{
    public interface IResidentialAddresRepository
    {
        Task<List<ResidentialAddres>> GetAllAsync();
        Task<ResidentialAddres?> GetByIdAsync(int id);
        Task<bool> ResidentialAddresExist(int id);
        Task<ResidentialAddres?> UpdateAddresAsync(int id, UpdateResidentialAddresRequestDto updateResident);
        Task<ResidentialAddres> CreateAddressAsync(ResidentialAddres residentialAddres);

    }
}