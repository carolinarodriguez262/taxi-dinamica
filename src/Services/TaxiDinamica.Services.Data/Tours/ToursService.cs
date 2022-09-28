namespace TaxiDinamica.Services.Data.Tours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class ToursService : IToursService
    {
        private readonly IDeletableEntityRepository<Tour> toursRepository;

        public ToursService(IDeletableEntityRepository<Tour> toursRepository)
        {
            this.toursRepository = toursRepository;
        }

        public async Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId)
        {
            var tours =
                await this.toursRepository
                .All()
                .Where(x => x.PartnerId == partnerId)
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return tours;
        }

        public async Task<int> AddAsync(TimeSpan tourStartTime, TimeSpan tourEndTime, string tourStartAddress, string tourEndAddress, string docTourUrl, bool isNormalTour, string partnerId)
        {
            var tour = new Tour
            {
                TourStartTime = tourStartTime,
                TourEndTime = tourEndTime,
                TourStartAddress = tourStartAddress,
                TourEndAddress = tourEndAddress,
                DocTourUrl = docTourUrl,
                IsNormalTour = isNormalTour,
                PartnerId = partnerId,
            };

            await this.toursRepository.AddAsync(tour);
            await this.toursRepository.SaveChangesAsync();

            return tour.Id;
        }
    }
}
