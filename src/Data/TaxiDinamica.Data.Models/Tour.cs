namespace TaxiDinamica.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Tour : BaseDeletableModel<int>
    {
        public Tour()
        {
            this.Directions = new HashSet<Direction>();
        }

        public TimeSpan TourStartTime { get; set; }

        public TimeSpan TourEndTime { get; set; }

        public string TourStartAddress { get; set; }

        public string TourEndAddress { get; set; }

        public string DocTourUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string PartnerId { get; set; }

        public virtual Partner Partner { get; set; }

        public virtual ICollection<Direction> Directions { get; set; }
    }
}
