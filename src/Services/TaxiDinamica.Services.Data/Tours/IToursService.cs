namespace TaxiDinamica.Services.Data.Tours
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IToursService
    {
        Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId);

        Task<int> AddAsync(TimeSpan tourStartTime, TimeSpan tourEndTime, string tourStartAddress, string tourEndAddress, string docTourUrl, bool isNormalTour, string partnerId);
    }
}
