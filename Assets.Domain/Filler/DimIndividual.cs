using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faker.Domain
{
    public class DimIndividual
    {
        [Key]
        public int IndividualKey { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public int DocumentNumber { get; set; }
        public string Email { get; set; }
        public int HospitalDistance { get; set; }
        public bool Vaccine1 { get; set; }
        public bool Vaccine2 { get; set; }
    }
}
