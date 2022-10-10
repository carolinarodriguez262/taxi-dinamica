namespace TaxiDinamica.Services.Data.PartnerServicesServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class PartnerServicesService : IPartnerServicesService
    {
        private readonly IDeletableEntityRepository<PartnerService> partnerServicesRepository;

        public PartnerServicesService(IDeletableEntityRepository<PartnerService> partnerServicesRepository)
        {
            this.partnerServicesRepository = partnerServicesRepository;
        }

        public async Task<T> GetByIdAsync<T>(string partnerId, int serviceId)
        {
            var partnerService =
                await this.partnerServicesRepository
                .All()
                .Where(x => x.PartnerId == partnerId && x.ServiceId == serviceId)
                .To<T>().FirstOrDefaultAsync();
            return partnerService;
        }

        public async Task<IEnumerable<T>> GetAllByPartnerIdAsync<T>(string partnerId)
        {
            var partnerService =
                await this.partnerServicesRepository
                .All()
                .Where(x => x.PartnerId == partnerId)
                .To<T>().ToListAsync();
            return partnerService;
        }

        public async Task AddAsync(string partnerId, IEnumerable<int> servicesIds)
        {
            foreach (var serviceId in servicesIds)
            {
                await this.partnerServicesRepository.AddAsync(new PartnerService
                {
                    PartnerId = partnerId,
                    ServiceId = serviceId,
                    Available = true,
                });
            }

            await this.partnerServicesRepository.SaveChangesAsync();
        }

        public async Task AddAsync(IEnumerable<string> partnersIds, int serviceId)
        {
            foreach (var partnerId in partnersIds)
            {
                await this.partnerServicesRepository.AddAsync(new PartnerService
                {
                    PartnerId = partnerId,
                    ServiceId = serviceId,
                    Available = true,
                });
            }

            await this.partnerServicesRepository.SaveChangesAsync();
        }

        public async Task ChangeAvailableStatusAsync(string partnerId, int serviceId)
        {
            var partnerService =
                await this.partnerServicesRepository
                .All()
                .Where(x => x.PartnerId == partnerId
                            && x.ServiceId == serviceId)
                .FirstOrDefaultAsync();

            partnerService.Available = !partnerService.Available;

            await this.partnerServicesRepository.SaveChangesAsync();
        }
    }
}
