using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ResidentialAddres;
using api.Dtos.UserData;
using api.Models;

namespace api.Mapper
{
    public static class ResidentialAddresMappers
    {
        public static ResidentialAddresDto ToAddresStockDto(this ResidentialAddres addresModel)
        {
            return new ResidentialAddresDto
            {
                Id = addresModel.Id,
                Country = addresModel.Country,
                City = addresModel.City,
                Street = addresModel.Street,
                UserDataId = addresModel.UserDataId,
            };
        }

        public static ResidentialAddres ToAddresStockFromCreateDto(this CreateRessidentAddressRequestDto createDto)
        {
            return new ResidentialAddres
            {
                Country = createDto.Country,
                City = createDto.City,
                Street = createDto.Street,
            };
        }
    }
}