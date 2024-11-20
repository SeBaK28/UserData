using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlaceOfBirth;
using api.Models;

namespace api.Mapper
{
    public static class PlaceOfBirthMapper
    {
        public static PlaceOfBirthDto ToPlaceOfBirthDto(this PlaceOfBirth placeOfBirth)
        {
            return new PlaceOfBirthDto
            {
                Id = placeOfBirth.Id,
                Country = placeOfBirth.Country,
                City = placeOfBirth.City,
                Street = placeOfBirth.Street,
                HouseNumber = placeOfBirth.HouseNumber,
                UserDataId = placeOfBirth.UserDataId,
            };
        }
    }
}