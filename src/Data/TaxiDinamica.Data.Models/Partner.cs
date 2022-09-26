namespace TaxiDinamica.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Partner : BaseDeletableModel<string>
    {
        public Partner()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Services = new HashSet<PartnerService>();
        }

        public string Placa { get; set; }

        public string ImageUrl { get; set; }

        public string DocPaseUrl { get; set; }

        public string DocCedulaUrl { get; set; }

        public string DocTarjetonUrl { get; set; }

        public string DocSoatUrl { get; set; }

        public string DocLicenciaUrl { get; set; }

        public string DocOperacionUrl { get; set; }

        public string DocSeguroUrl { get; set; }

        public string DocTecnoUrl { get; set; }

        public string Schedule { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string DriverName { get; set; }

        public string DriverContact { get; set; }

        public bool Available { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<PartnerService> Services { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
