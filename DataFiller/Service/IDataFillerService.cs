using Holdings.Domain.Filler;
using System.Threading.Tasks;

namespace DataFiller.Service
{
    public interface IDataFillerService
    {
        Task<bool> FillData();
        Task<DimCustomer> GetCustomerByKey(int key);
        Task<DimGeography> GetGeographyByKey(int key);
        Task<bool> FillDates();

    }
}
