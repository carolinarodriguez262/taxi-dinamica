namespace TaxiDinamica.Web.ViewModels.Directions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DirectionInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Hora Estimada Inicio")]
        public TimeSpan? EstimatedStartTime { get; set; }

        [Display(Name = "Hora Estimada Final")]
        public TimeSpan? EstimatedEndTime { get; set; }

        public int TourId { get; set; }
    }
}
