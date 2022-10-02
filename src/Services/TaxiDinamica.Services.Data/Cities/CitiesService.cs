namespace TaxiDinamica.Services.Data.Cities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cities =
                await this.citiesRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return cities;
        }

        public async Task AddAsync(string name)
        {
            await this.citiesRepository.AddAsync(new City
            {
                Name = name,
            });
            await this.citiesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city =
                await this.citiesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.citiesRepository.Delete(city);
            await this.citiesRepository.SaveChangesAsync();
        }
    }
}
