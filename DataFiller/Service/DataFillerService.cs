using Assets.Repository.Context;
using Bogus;
using Faker.Domain;
using Faker.Domain.Constants;
using Faker.Domain.Dtos.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataFiller.Service
{
    public class DataFillerService : IDataFillerService
    {
        private readonly HoldingsContext _context;
        private readonly int _occupationsTotalWeight;
        private readonly int _demographicsTotalWeight;

        public DataFillerService(HoldingsContext context)
        {
            _context = context;
            _occupationsTotalWeight = Constants.Occupations.Sum(x => x.weight);
            _demographicsTotalWeight = Constants.Demographic.Sum(x => x.weight);
        }

        public async Task<bool> FillData()
        {
            Random rand = new Random();
            var population = _context.DimIndividual.ToList();

            foreach (var pop in population)
            {
                var vaccinated = pop.Vaccine1 && pop.Vaccine2;
                var fact = new FactDistribution
                {
                    IndividualKey = pop.IndividualKey,
                    VaccineKey = rand.Next(2, 11),
                    HospitalKey = rand.Next(1, Constants.AmountHospitals),
                    Priority = vaccinated ? 0 : calculatePriority(pop.DOB, pop.Occupation, pop.Vaccine1, pop.HospitalDistance),
                    Vaccinated = vaccinated,
                };
                await _context.FactDistribution.AddAsync(fact);
            }
            return await _context.SaveChangesAsync() > -1;
        }

        private int calculatePriority(DateTime DOB, string occupation, bool vac1, int hospDistance)
        {
            int initial = 0;
            initial += (DateTime.Now.Year - DOB.Year) / 4;
            if (vac1)
            {
                initial += 20;
            }
            initial += hospDistance / 10;
            initial += occupation switch
            {
                "Essential_A" => 25,
                "Essential_B" => 20,
                "Essential_C" => 15,
                "Essential_D" => 10,
                "PublicPerson_A" => 15,
                "PublicPerson_B" => 10,
                "PublicPerson_C" => 5,
                "PublicPerson_D" => 3,
                "NonEssential_A" => 4,
                "NonEssential_B" => 2,
                _ => 2,
            };
            return initial > 100 ? 100 : initial;
        }

        public async Task<bool> FillDates()
        {
            var date = DateTime.Now.Date.AddYears(-5);

            while (date < DateTime.Now.Date)
            {
                var newDate = new DimDate
                {
                    DateKey = int.Parse($"{date.Year}{date.Month:d2}{date.Day:d2}"),
                    FullDateAlternateKey = date.Date,
                    CalendarQuarter = (byte)((date.Month + 2) / 3),
                    CalendarSemester = (byte)(date.Month < 6 ? 1 : 2),
                    CalendarYear = (short)date.Year
                };
                await _context.DimDate.AddAsync(newDate);
                date = date.AddDays(1);
            }
            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<bool> FillHospital()
        {
            Random rand = new Random();

            var hospitals = new Faker<DimHospital>()
                .RuleFor(x => x.Name, f => $"Hospital - {f.Person.FirstName}")
                .RuleFor(x => x.Direction, f => $"{f.Address.StreetName()} {f.Address.StreetAddress()}")
                .RuleFor(x => x.HealthWorkers, f => f.Random.Number(150, 1000))
                .RuleFor(x => x.Capacity, (f, u) => u.HealthWorkers * f.Random.Number(3, 6))
                .RuleFor(x => x.GeographyKey, f => f.Random.Number(10100, 230500))
                .Generate(Constants.AmountHospitals);
            
            foreach(var hosp in hospitals)
            {
                await _context.AddAsync(hosp);
            }
            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<bool> FillIndividual(int amount)
        {
            int year = DateTime.Now.Date.Year;
            var individuals = new Faker<DimIndividual>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.DOB, f => getRandomDOB(f.Person.DateOfBirth, f.Random.Number(0, _demographicsTotalWeight)))
                .RuleFor(x => x.DocumentNumber, (f, u) =>
                    {
                        var age = year - u.DOB.Year;
                        return age switch
                        {
                            int n when (n <= 15) => f.Random.Number(Constants.DocumentsUpTo15.MinDoc, Constants.DocumentsUpTo15.MaxDoc),
                            int n when (n > 15 && n <= 25) => f.Random.Number(Constants.Documents16_25.MinDoc, Constants.Documents16_25.MaxDoc),
                            int n when (n > 25 && n <= 65) => f.Random.Number(Constants.Documents26_65.MinDoc, Constants.Documents26_65.MaxDoc),
                            int n when (n > 65) => f.Random.Number(Constants.Documents65Up.MinDoc, Constants.Documents65Up.MaxDoc),
                            _ => f.Random.Number(Constants.DocumentsUpTo15.MinDoc, Constants.Documents65Up.MaxDoc),
                        };
                    }
                )
                .RuleFor(x => x.Gender, f => f.Person.Gender.ToString())
                .RuleFor(x => x.HospitalDistance, f => f.Random.Number(1, 350))
                .RuleFor(x => x.Occupation, f => getRandomOccupation(f.Random.Number(0, _occupationsTotalWeight)))
                .RuleFor(x => x.Vaccine1, (f, u) => f.Random.Bool(.35f))
                .RuleFor(x => x.Vaccine2, (f, u) => u.Vaccine1 && f.Random.Bool(.2f))
                .Generate(amount);

            foreach (var ind in individuals)
            {
                await _context.DimIndividual.AddAsync(ind);
            }

            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<bool> FillVaccines()
        {
            Random rand = new Random();
            foreach (var vaccine in Constants.Vaccines)
            {
                vaccine.LaboratoryKey = rand.Next(10025, 11000);
                await _context.DimVaccines.AddAsync(vaccine);
            }
            return await _context.SaveChangesAsync() > -1;
        }

        public async Task<IEnumerable<ProportionDto>> GetIndividualProportions()
        {
            int totalIndividuals = await _context.DimIndividual.CountAsync();
            var orderedIndividuals = await _context.DimIndividual.OrderBy(x => x.DOB).ToListAsync();
            var yearFrom = orderedIndividuals.First().DOB.Year;
            var yearTo = orderedIndividuals.Last().DOB.Year + 10;
            var proportions = new List<ProportionDto>();
            var auxYear = yearFrom + 10;
            while (auxYear < yearTo)
            {
                var dto = new ProportionDto
                {
                    YearFrom = yearFrom,
                    YearTo = auxYear,
                    Occupations = Constants.Occupations.ToDictionary(x => x.Occupation, x => (double)0),
                    AgeFrom = DateTime.Now.Date.Year - yearFrom,
                    AgeTo = DateTime.Now.Date.Year - auxYear
            };
                yearFrom += 10;
                auxYear += 10;
                proportions.Add(dto);
            }

            var keys = Constants.Occupations.Select(x => x.Occupation).ToList();

            foreach (ProportionDto dto in proportions)
            {
                var population = orderedIndividuals.Where(x => x.DOB.Year >= dto.YearFrom && x.DOB.Year <= dto.YearTo).ToList();
                dto.PopulationPercentage = Math.Round((double)(population.Count() / (double)orderedIndividuals.Count) * 100, 2);
                dto.Vaccine1Percentage = Math.Round((double)(population.Count(x => x.Vaccine1) / (double)population.Count) * 100, 2);
                dto.Vaccine2Percentage = Math.Round((double)(population.Count(x => x.Vaccine2) / (double)population.Count) * 100, 2);
                foreach (string occ in keys)
                {
                    dto.Occupations[occ] = Math.Round((double)(population.Count(x => x.Occupation.Equals(occ)) / (double)population.Count) * 100, 2);
                }
            }

            return proportions;
        }

        private string getRandomOccupation(int rand)
        {
            // A Weighted int between 0 and Occupation lenght. 
            foreach (var (Occupation, weight) in Constants.Occupations)
            {
                if ((rand -= weight) < 0)
                    return Occupation;
            }
            return Constants.Occupations[Constants.Occupations.Length - 1].Occupation; // Last occupation
        }

        private DateTime getRandomDOB(DateTime date, int rand)
        {
            Random r = new Random();
            foreach (var (yearFrom, yearTo, weight) in Constants.Demographic)
            {
                if ((rand -= weight) < 0)
                {
                    var year = r.Next(yearFrom, yearTo);
                    return !DateTime.IsLeapYear(year) && date.Month == 2 && date.Day == 29 ? new DateTime(year, date.Month, date.Day - 1) : new DateTime(year, date.Month, date.Day);
                }
            }
            return date;
        }

        //private (int dateKey, DateTime date) getNextDate(DateTime date)
        //{
        //    Random rand = new Random();
        //    date = date.AddDays(rand.Next(1, 3));
        //    return (int.Parse($"{date.Year}{date.Month:d2}{date.Day:d2}"), date);
        //}

        //private int getNextProd()
        //{
        //    Random rand = new Random();
        //    return rand.Next(prodLow, prodMax);
        //}
        //private int getNextCustomer()
        //{
        //    Random rand = new Random();
        //    return rand.Next(custLow, custMax);
        //}
        //private int getNextGeography()
        //{
        //    Random rand = new Random();
        //    return rand.Next(geoLow, geoMax);
        //}
        //private int getNextOrganization()
        //{
        //    Random rand = new Random();
        //    return rand.Next(orgLow, orgMax);
        //}
        //private async Task<DimPromotion> getNextPromotion()
        //{
        //    if (gotLucky == 0)
        //    {
        //        Random rand = new Random();
        //        var prom = rand.Next(1, promMax);
        //        gotLucky = rand.Next(1, 10);
        //        return await _context.DimPromotion.FindAsync(prom);
        //    }
        //    gotLucky--;
        //    return noDiscountDim;
        //}

        //private SaleDto getNextSale(DimProduct product, DimPromotion promotion)
        //{
        //    Random rand = new Random();
        //    var result = new SaleDto() { Ordered = rand.Next(1, 150) };
        //    result.Amount = ((double)product.ListPrice * result.Ordered) - (((double)product.ListPrice * result.Ordered) * promotion.DiscountPct);
        //    result.Utility = result.Amount - ((double)product.StandardCost * result.Ordered);

        //    if (result.Utility < 0)
        //        result.Utility = 0;

        //    return result;
        //}

        //private class SaleDto
        //{
        //    public double Amount { get; set; }
        //    public int Ordered { get; set; }
        //    public double Utility { get; set; }
        //}

    }
}
