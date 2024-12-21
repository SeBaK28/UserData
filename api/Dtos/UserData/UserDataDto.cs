using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlaceOfBirth;
using api.Dtos.ResidentialAddres;
using Newtonsoft.Json;

namespace api.Dtos.UserData
{
    public class UserDataDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum name length is 2 chars")]
        [MaxLength(35, ErrorMessage = "Maximum name length is 35 chars")]
        public string? Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum Second name is 2 chars")]
        [MaxLength(70, ErrorMessage = "Maximum Second name is 70 chars")]
        public string? SecondName { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public string? DateOfBirth { get; set; }

        public DateTime DateOfCreateAccount { get; set; } = DateTime.Now;

        public List<PlaceOfBirthDto>? PlaceOfBirths { get; set; }
        public List<ResidentialAddresDto>? residentialAddresProp { get; set; }

    }
}