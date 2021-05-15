using System.Threading.Tasks;

namespace DataFiller.Service
{
    public interface IDataFillerService
    {
        Task<bool> FillData();
        Task<bool> FillDates();
        Task<bool> FillVaccines();
        Task<bool> FillIndividual();
        Task<bool> FillHospital();
    }
}
