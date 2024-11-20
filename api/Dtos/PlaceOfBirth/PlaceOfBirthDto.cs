using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PlaceOfBirth
{
    public class PlaceOfBirthDto
    {
        public int Id { get; set; }
        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public int HouseNumber { get; set; }

        public int UserDataId { get; set; }
    }
}