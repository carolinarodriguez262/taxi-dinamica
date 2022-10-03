namespace TaxiDinamica.Web.ViewModels.Directions
{
    using System;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class DirectionViewModel : IMapFrom<Direction>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public TimeSpan EstimatedStartTime { get; set; }

        public TimeSpan EstimatedEndTime { get; set; }

        public int TourId { get; set; }
    }
}
