namespace TaxiDinamica.Services.Data.Schedules
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchedulesService
    {
        Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId);

        Task<int> AddAsync(string day, string partnerId);

        Task<int> EditAsync(int id, string day, string partnerId);

        Task DeleteAsync(int id);
    }
}
