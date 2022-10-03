namespace TaxiDinamica.Services.Data.Directions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDirectionsService
    {
        Task<IEnumerable<T>> GetAllByTourAsync<T>(int tourId);

        Task<int> AddAsync(string address, TimeSpan estimatedStartTime, TimeSpan estimatedEndTime, int tourId);

        Task<int> EditAsync(int id, string address, TimeSpan estimatedStartTime, TimeSpan estimatedEndTime, int tourId);
    }
}
