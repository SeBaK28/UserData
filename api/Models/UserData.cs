using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? SecondName { get; set; }

        public string? Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfCreateAccount { get; set; } = DateTime.Now;

        public List<PlaceOfBirth> PlaceOfBirths { get; set; } = new List<PlaceOfBirth>();

    }

}