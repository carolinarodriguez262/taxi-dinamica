namespace TaxiDinamica.Services.Data.PartnerServicesServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartnerServicesService
    {
        Task<T> GetByIdAsync<T>(string partnerId, int serviceId);

        Task AddAsync(string partnerId, IEnumerable<int> servicesIds);

        Task AddAsync(IEnumerable<string> partnersIds, int serviceId);

        Task ChangeAvailableStatusAsync(string partnerId, int serviceId);

        Task<IEnumerable<T>> GetAllByPartnerIdAsync<T>(string partnerId);
    }
}
