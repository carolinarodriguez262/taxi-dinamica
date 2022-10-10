namespace TaxiDinamica.Web.ViewModels.Partners
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using TaxiDinamica.Web.ViewModels.Tours;

    public class PartnerViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }

        public string Placa { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Pase para Transporte Publico")]
        public string DocPaseUrl { get; set; }

        [Display(Name = "Cédula del Conductor")]
        public string DocCedulaUrl { get; set; }

        [Display(Name = "Tarjetón")]
        public string DocTarjetonUrl { get; set; }

        [Display(Name = "SOAT")]
        public string DocSoatUrl { get; set; }

        [Display(Name = "Licencia")]
        public string DocLicenciaUrl { get; set; }

        [Display(Name = "Tarjeta de Operación")]
        public string DocOperacionUrl { get; set; }

        [Display(Name = "Seguro Extra y Contractual")]
        public string DocSeguroUrl { get; set; }

        [Display(Name = "Revisión Tecnomecánica")]
        public string DocTecnoUrl { get; set; }
        public string OwnerId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public double Rating { get; set; }
        public int RatersCount { get; set; }
        public int AppointmentsCount { get; set; }
        public TourViewModel TourViewModel { get; set; }

    }
}
