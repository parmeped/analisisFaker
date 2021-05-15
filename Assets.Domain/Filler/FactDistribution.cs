using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faker.Domain
{
    public class FactDistribution
    {
        [Key]
        public int Id { get; set; }
        public int IndividualKey { get; set; }
        public int VaccineKey { get; set; }
        public int HospitalKey { get; set; }
        public int Priority { get; set; }
        public bool Vaccinated { get; set; }
    }
}
