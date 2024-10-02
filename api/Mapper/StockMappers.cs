using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserData;
using api.Models;

namespace api.Mapper
{
    public static class StockMappers
    {
        public static UserDto ToStockDto(this UserData dataModel)
        {
            return new UserDto
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                SecondName = dataModel.SecondName,
                Sex = dataModel.Sex,
                DateOfBirth = dataModel.DateOfBirth,
                DateOfCreateAccount = dataModel.DateOfCreateAccount
            };
        }

        public static UserData ToStockFromCreateDto(this CreateStockRequestDto userDto)
        {
            return new UserData
            {
                Name = userDto.Name,
                SecondName = userDto.SecondName,
                Sex = userDto.Sex,
                DateOfBirth = userDto.DateOfBirth,
            };
        }
    }
}