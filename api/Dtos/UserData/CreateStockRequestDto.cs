using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserData
{
    public class CreateStockRequestDto
    {
        public string? Name { get; set; }

        public string? SecondName { get; set; }

        public string? Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}