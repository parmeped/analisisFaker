using Assets.Repository.Context;
using Faker.Domain;
using System;
using System.Threading.Tasks;

namespace DataFiller.Service
{
    public class DataFillerService : IDataFillerService
    {
        private readonly HoldingsContext _context;

        public DataFillerService(HoldingsContext context)
        {
            _context = context;
        }

        public async Task<bool> FillData()
        {
            throw new NotImplementedException();
        }

        //private int prodLow;
        //private int prodMax;
        //private int custLow;
        //private int custMax;
        //private int geoLow;
        //private int geoMax;
        //private int orgLow;
        //private int orgMax;
        //private int promMax;
        //private int gotLucky;
        //private DimPromotion noDiscountDim;



        //public async Task<bool> FillData()
        //{
        //    prodLow = await _context.DimProduct.OrderBy(x => x.ProductKey).Select(x => x.ProductKey).FirstAsync();
        //    prodMax = await _context.DimProduct.OrderByDescending(x => x.ProductKey).Select(x => x.ProductKey).FirstAsync();
        //    custLow = await _context.DimCustomer.OrderBy(x => x.CustomerKey).Select(x => x.CustomerKey).FirstAsync();
        //    custMax = await _context.DimCustomer.OrderByDescending(x => x.CustomerKey).Select(x => x.CustomerKey).FirstAsync();
        //    geoLow = await _context.DimGeography.OrderBy(x => x.GeographyKey).Select(x => x.GeographyKey).FirstAsync();
        //    geoMax = await _context.DimGeography.OrderByDescending(x => x.GeographyKey).Select(x => x.GeographyKey).FirstAsync();
        //    orgLow = await _context.DimOrganization.OrderBy(x => x.OrganizationKey).Select(x => x.OrganizationKey).FirstAsync();
        //    orgMax = await _context.DimOrganization.OrderByDescending(x => x.OrganizationKey).Select(x => x.OrganizationKey).FirstAsync();
        //    promMax = await _context.DimPromotion.OrderByDescending(x => x.PromotionKey).Select(x => x.PromotionKey).FirstAsync();
        //    noDiscountDim = await _context.DimPromotion.FindAsync(1);

        //    Random rand = new Random();
        //    int limit = 150, filled = 0;
        //    int amountToFill = rand.Next(1, 500);
        //    var date = DateTime.Now.Date.AddYears(-5);
        //    int dateKey, prodKey;

        //    (dateKey, date) = getNextDate(date);
        //    prodKey = getNextProd();

        //    var customerKey = getNextCustomer();
        //    var geoKey = getNextGeography();
        //    var orgKey = getNextOrganization();
        //    var promotionDim = await getNextPromotion();

        //    var prodDim = await _context.DimProduct.FindAsync(prodKey);
        //    var prodSubCatDim = await _context.DimProductSubcategory.FindAsync(prodDim.ProductSubcategoryKey);
        //    var sale = getNextSale(prodDim, promotionDim);

        //    for (int i = 0; i < limit;)
        //    {
        //        while (filled < amountToFill)
        //        {
        //            var fact = new FactSales
        //            {
        //                Id = i + 1,
        //                DateKey = dateKey,
        //                ProductKey = prodKey,
        //                ProductCategoryKey = prodSubCatDim?.ProductCategoryKey ?? 0,
        //                ProductSubcategoryKey = prodDim?.ProductSubcategoryKey ?? 0,
        //                CustomerKey = customerKey,
        //                GeographicKey = geoKey,
        //                OrganizationKey = orgKey,
        //                PromotionKey = promotionDim.PromotionKey,
        //                Amount_ordered = sale.Ordered,
        //                Total_amount = (decimal)sale.Amount,
        //                Utility = (decimal)sale.Utility
        //            };
        //            prodKey = getNextProd();
        //            prodDim = await _context.DimProduct.FindAsync(prodKey);
        //            prodSubCatDim = await _context.DimProductSubcategory.FindAsync(prodDim.ProductSubcategoryKey);
        //            customerKey = getNextCustomer();
        //            geoKey = getNextGeography();
        //            orgKey = getNextOrganization();
        //            promotionDim = await getNextPromotion();
        //            sale = getNextSale(prodDim, promotionDim);
        //            await _context.FactSales.AddAsync(fact);
        //            filled++;
        //            i++;
        //        }
        //        await _context.SaveChangesAsync();
        //        filled = 0;
        //        amountToFill = rand.Next(1, 500);
        //        (dateKey, date) = getNextDate(date);
        //        prodKey = getNextProd();
        //        prodDim = await _context.DimProduct.FindAsync(prodKey);
        //        prodSubCatDim = await _context.DimProductSubcategory.FindAsync(prodDim.ProductSubcategoryKey);
        //        customerKey = getNextCustomer();
        //        geoKey = getNextGeography();
        //        orgKey = getNextOrganization();
        //        promotionDim = await getNextPromotion();
        //        sale = getNextSale(prodDim, promotionDim);
        //    }
        //    return true;
        //}

        //public async Task<DimCustomer> GetCustomerByKey(int key)
        //{
        //    return await _context.DimCustomer.FirstOrDefaultAsync(x => x.CustomerKey == key);
        //}

        //public async Task<DimGeography> GetGeographyByKey(int key)
        //{
        //    return await _context.DimGeography.FirstOrDefaultAsync(x => x.GeographyKey == key);
        //}

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
            // todo adentro de for
            var hosp = new DimHospital()
            {
                HospitalKey = 1, // Un int que sube por cada uno creado
                Direction = "data falopa",
                Capacity = rand.Next(1, 30),
                HealthWorkers = rand.Next(1, 30),
                Name = "Hospital chamullo"
            };
            await _context.AddAsync(hosp);
            return await _context.SaveChangesAsync() > -1;
        }

        public Task<bool> FillIndividual()
        {
            throw new NotImplementedException();
        }

        public Task<bool> FillVaccines()
        {
            throw new NotImplementedException();
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
