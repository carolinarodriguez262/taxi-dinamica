namespace TaxiDinamica.Web.ViewModels.Partners
{
    using System.Collections.Generic;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using TaxiDinamica.Web.ViewModels.Tours;

    public class PartnerWithServicesViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }

        public string Placa { get; set; }

        public string ImageUrl { get; set; }
        
        public string OwnerId { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }

        public string DriverName { get; set; }

        public string DriverContact { get; set; }

        public virtual ICollection<PartnerServiceViewModel> Services { get; set; }

        public virtual ICollection<TourViewModel> Tours { get; set; }
    }
}
