using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserData;
using api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace api.Mapper
{
    public static class UserDataMappers
    {
        public static UserDataDto ToStockDto(this UserData dataModel)
        {
            return new UserDataDto
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                SecondName = dataModel.SecondName,
                Sex = dataModel.Sex,
                DateOfBirth = dataModel.DateOfBirth.ToString("dd/MM/yyyy"),
                DateOfCreateAccount = dataModel.DateOfCreateAccount,
                DateOfAccess = dataModel.DateOfAccess,
                PlaceOfBirths = dataModel.PlaceOfBirths.Select(c => c.ToPlaceOfBirthDto()).ToList()
            };
        }

        public static UserData ToStockFromCreateDto(this CreateUserDataRequestDto userDto)
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