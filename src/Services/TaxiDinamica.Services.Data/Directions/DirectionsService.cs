namespace TaxiDinamica.Services.Data.Directions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class DirectionsService : IDirectionsService
    {
        private readonly IDeletableEntityRepository<Direction> directionsRepository;

        public DirectionsService(IDeletableEntityRepository<Direction> directionsRepository)
        {
            this.directionsRepository = directionsRepository;
        }

        public async Task<IEnumerable<T>> GetAllByTourAsync<T>(int tourId)
        {
            var directions =
                await this.directionsRepository
                .All()
                .Where(x => x.TourId == tourId)
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return directions;
        }

        public async Task<int> AddAsync(string address, TimeSpan estimatedStartTime, TimeSpan estimatedEndTime, int tourId)
        {
            var direction = new Direction
            {
                Address = address,
                EstimatedStartTime = estimatedStartTime,
                EstimatedEndTime = estimatedEndTime,
                TourId = tourId,
            };

            await this.directionsRepository.AddAsync(direction);
            await this.directionsRepository.SaveChangesAsync();

            return direction.Id;
        }

        public async Task<int> EditAsync(int id, string address, TimeSpan estimatedStartTime, TimeSpan estimatedEndTime, int tourId)
        {
            var direction = new Direction
            {
                Id = id,
                Address = address,
                EstimatedStartTime = estimatedStartTime,
                EstimatedEndTime = estimatedEndTime,
                TourId = tourId,
            };

            this.directionsRepository.Update(direction);
            await this.directionsRepository.SaveChangesAsync();

            return direction.Id;
        }
    }
}
