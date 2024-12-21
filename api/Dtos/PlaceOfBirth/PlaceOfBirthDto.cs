using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PlaceOfBirth
{
    public class PlaceOfBirthDto
    {
        public int Id { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Maximum City Name is 250 chars")]
        public string? City { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum Street Name is 100 chars")]
        public string? Street { get; set; }
        [Required]
        [Range(1, 1000)]
        public int? HouseNumber { get; set; }

        public int UserDataId { get; set; }
    }
}