using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlaceOfBirth;
using api.Dtos.ResidentialAddres;

namespace api.Dtos.UserData
{
    public class UserDataDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SecondName { get; set; }

        public string? Sex { get; set; }

        public string? DateOfBirth { get; set; }

        public DateTime DateOfCreateAccount { get; set; } = DateTime.Now;

        public List<PlaceOfBirthDto>? PlaceOfBirths { get; set; }
        public List<ResidentialAddresDto>? residentialAddresProp { get; set; }

    }
}