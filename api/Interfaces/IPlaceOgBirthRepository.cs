using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPlaceOgBirthRepository
    {
        Task<List<PlaceOfBirth>> GetAllAsync();
        Task<PlaceOfBirth?> GetByIdAsync(int id);
    }
}