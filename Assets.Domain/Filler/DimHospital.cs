using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Faker.Domain
{
    // Aprox entre 1000 - 3000
    public class DimHospital
    {
        [Key]
        public int HospitalKey { get; set; } 
        public int GeographyKey { get; set; }
        public string Name { get; set; } 
        public string Direction { get; set; }
        public int Capacity { get; set; } 
        public int HealthWorkers { get; set; }
    }
}
