using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaxiDinamica.Web.ViewModels.Directions
{
    public class DirectionInputModel
    {
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Hora Estimada Inicio")]
        public TimeSpan? EstimatedStartTime { get; set; }

        [Display(Name = "Hora Estimada Final")]
        public TimeSpan? EstimatedEndTime { get; set; }

        public int TourId { get; set; }
    }
}
