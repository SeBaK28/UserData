using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ResidentialAddres
{
    public class CreateRessidentAddressRequestDto
    {
        [Required]
        public string? Country { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Maximum City Name is 250 chars")]
        public string? City { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum Street Name is 100 chars")]
        public string? Street { get; set; }
        public int UserDataId { get; set; }
    }
}