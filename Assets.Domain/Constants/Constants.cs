using System;
using System.Collections.Generic;
using System.Text;

namespace Faker.Domain.Constants
{
    public static class Constants
    {
        public static List<DimVaccines> Vaccines = new List<DimVaccines>
        {
            new DimVaccines
            {
                Name = "Moderna",
                Effectiveness = 94
            },
            new DimVaccines
            {
                Name = "Pfizer",
                Effectiveness = 95
            },
            new DimVaccines
            {
                Name = "Sputnik",
                Effectiveness = 92
            },
            new DimVaccines
            {
                Name = "AstraZeneca",
                Effectiveness = 81
            },
            new DimVaccines
            {
                Name = "BBIBP",
                Effectiveness = 78
            },
            new DimVaccines
            {
                Name = "CoronaVac",
                Effectiveness = 84
            },
            new DimVaccines
            {
                Name = "Novavax",
                Effectiveness = 89
            },
            new DimVaccines
            {
                Name = "Johnson&Johnson",
                Effectiveness = 66
            },
            new DimVaccines
            {
                Name = "Covaxin",
                Effectiveness = 78
            },
             new DimVaccines
            {
                Name = "Convidecia",
                Effectiveness = 66
            }
        };
        public static (string Occupation, int weight)[] Occupations =
        {
             ("PublicPerson_A", 20)
            ,("PublicPerson_B", 50)
            ,("PublicPerson_C", 70)
            ,("PublicPerson_D", 100)
            ,("Essential_A", 1000)
            ,("Essential_B", 1500)
            ,("Essential_C", 1800)
            ,("Essential_D", 2100)
            ,("NonEssential_A", 10000)
            ,("NonEssential_B", 11000)
        };
        public static (int yearFrom, int yearTo, int weight)[] Demographic =
        {
            (1940, 1945, 20),
            (1946, 1950, 35),
            (1951, 1960, 55),
            (2001, 2010, 180),
            (1991, 2000, 200),
            (1961, 1970, 250),
            (1971, 1980, 280),
            (1981, 1990, 290)
        };

        public static (int MinDoc, int MaxDoc) DocumentsUpTo15 = (50000000, 55000000);
        public static (int MinDoc, int MaxDoc) Documents16_25 = (40000000, 49999999);
        public static (int MinDoc, int MaxDoc) Documents26_65 = (20000000, 39999999);
        public static (int MinDoc, int MaxDoc) Documents65Up = (13000000, 19999999);
    }
}
