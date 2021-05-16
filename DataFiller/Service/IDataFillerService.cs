using Faker.Domain.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataFiller.Service
{
    public interface IDataFillerService
    {
        Task<bool> FillData();
        Task<bool> FillDates();
        Task<bool> FillVaccines();
        Task<bool> FillIndividual(int amount);
        Task<bool> FillHospital();
        Task<IEnumerable<ProportionDto>> GetIndividualProportions();
    }
}
