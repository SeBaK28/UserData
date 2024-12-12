using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ResidentialAddres
{
    public class UpdateResidentialAddresRequestDto
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}