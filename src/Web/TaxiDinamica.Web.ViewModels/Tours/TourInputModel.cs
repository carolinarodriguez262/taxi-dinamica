namespace TaxiDinamica.Web.ViewModels.Tours
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;

    public class TourInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Hora Inicio Recorrido")]
        public TimeSpan TourStartTime { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Hora Fin Recorrido")]
        public TimeSpan TourEndTime { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Lugar Inicio Recorrido")]
        public string TourStartAddress { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Lugar Fin Recorrido")]
        public string TourEndAddress { get; set; }

        [Display(Name = "Mapa de Ruta")]
        public string DocTourUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Ruta Normal")]
        public bool IsNormalTour { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string PartnerId { get; set; }
    }
}
