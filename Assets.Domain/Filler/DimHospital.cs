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
        public int HospitalKey { get; set; } // Id, de 1 a n
        public string Name { get; set; } // Falopa
        public string Direction { get; set; } // Falopa
        public int Capacity { get; set; } // Usado para calcular prioridad luego. Capacity deberia ir a juego con HealthWorkers. entre 500 - 1500
        public int HealthWorkers { get; set; } // Falopa entre 150 - 550
    }
}
