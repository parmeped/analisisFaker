using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.Domain.Dtos.Response
{
    public class ProportionDto
    {
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public double PopulationPercentage { get; set; }
        public double Vaccine1Percentage { get; set; }
        public double Vaccine2Percentage { get; set; }
        public Dictionary<string, double> Occupations { get; set; }
    }
}
