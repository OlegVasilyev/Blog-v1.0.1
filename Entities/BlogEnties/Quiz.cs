using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Quiz : IdEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime DateBirt { get; set; }
        public string Sex { get; set; }
        public string NumberTelephone { get; set; }
        public bool Smoke { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
    }
}