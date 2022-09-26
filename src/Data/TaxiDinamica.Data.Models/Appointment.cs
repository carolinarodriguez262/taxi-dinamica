namespace TaxiDinamica.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Appointment : BaseDeletableModel<string>
    {
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string PartnerId { get; set; }

        public virtual Partner Partner { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual PartnerService PartnerService { get; set; }

        // The Partner can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }

        // Idea: For every past (and confirmed) appointment the User can Rate the Partner
        // But rating can be given only once for each appointment
        public bool? IsPartnerRatedByTheUser { get; set; }


        public string AddressStart { get; set; }


        public string AddressEnd { get; set; }

        public string Comment { get; set; }

        public string DriverMessage { get; set; }

        public int Price { get; set; } = 0;
    }
}
