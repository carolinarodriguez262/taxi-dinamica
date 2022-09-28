namespace TaxiDinamica.Services.Data.Schedules
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class SchedulesService : ISchedulesService
    {
        private readonly IDeletableEntityRepository<Schedule> scheduleRepository;

        public SchedulesService(IDeletableEntityRepository<Schedule> schedulesRepository)
        {
            this.scheduleRepository = schedulesRepository;
        }

        public async Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId)
        {
            var schedules =
                await this.scheduleRepository
                .All()
                .Where(x => x.PartnerId == partnerId)
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return schedules;
        }

        public async Task<int> AddAsync(string day, string partnerId)
        {
            var schedule = new Schedule
            {
                Day = day,
                PartnerId = partnerId,
            };

            await this.scheduleRepository.AddAsync(schedule);
            await this.scheduleRepository.SaveChangesAsync();

            return schedule.Id;
        }

    }
}
