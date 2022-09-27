namespace TaxiDinamica.Data.Models
{
    using System;

    using TaxiDinamica.Data.Common.Models;

    public class Direction : BaseDeletableModel<int>
    {
        public string Address { get; set; }

        public TimeSpan EstimatedStartTime { get; set; }

        public TimeSpan EstimatedEndTime { get; set; }

        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
