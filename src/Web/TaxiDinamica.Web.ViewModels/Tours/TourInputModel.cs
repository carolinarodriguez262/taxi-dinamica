namespace TaxiDinamica.Web.ViewModels.Tours
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using TaxiDinamica.Common;
    using TaxiDinamica.Web.ViewModels.Directions;

    public class TourInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Hora Inicio Recorrido")]
        public TimeSpan? TourStartTime { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Hora Fin Recorrido")]
        public TimeSpan? TourEndTime { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Lugar Inicio Recorrido")]
        public string TourStartAddress { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Lugar Fin Recorrido")]
        public string TourEndAddress { get; set; }

        [Display(Name = "Mapa de Ruta")]
        public IFormFile DocTourUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string TourType { get; set; }

        public List<string> DaysOfWeek { get; set; }

        public List<DirectionInputModel> DirectionsList { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string PartnerId { get; set; }
    }
}
