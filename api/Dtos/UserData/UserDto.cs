using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserData
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SecondName { get; set; }

        public string? Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfCreateAccount { get; set; } = DateTime.Now;

    }
}