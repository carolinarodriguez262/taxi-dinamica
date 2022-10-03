namespace TaxiDinamica.Web.ViewModels.Tours
{
    using System;
    using System.Collections.Generic;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using TaxiDinamica.Web.ViewModels.Directions;

    public class TourViewModel : IMapFrom<Tour>
    {
        public int Id { get; set; }

        public TimeSpan TourStartTime { get; set; }

        public TimeSpan TourEndTime { get; set; }

        public string TourStartAddress { get; set; }

        public string TourEndAddress { get; set; }

        public string DocTourUrl { get; set; }

        public bool IsNormalTour { get; set; }

        public string PartnerId { get; set; }

        public virtual ICollection<DirectionViewModel> Directions { get; set; }
    }
}
