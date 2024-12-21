using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserData
{
    public class CreateUserDataRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Minimum name length is 2 chars")]
        [MaxLength(35, ErrorMessage = "Maximum name length is 35 chars")]
        public string? Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum name length is 2 chars")]
        [MaxLength(70, ErrorMessage = "Maximum name length is 70 chars")]
        public string? SecondName { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}