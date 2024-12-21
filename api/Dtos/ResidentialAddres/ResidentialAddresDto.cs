using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Dtos.ResidentialAddres
{
    public class ResidentialAddresDto
    {
        public int Id { get; set; }
        [Required]
        //To będzie jako lista do wyboru
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