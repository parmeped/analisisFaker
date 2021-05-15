using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faker.Domain
{
    // pocas
    public class DimVaccines
    {
        [Key]
        public int VaccineKey { get; set; }
        public int LaboratoryKey { get; set; }
        public string Name { get; set; }
        public int Effectiveness { get; set; }
    }
}
