﻿namespace CeroFilas.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Partners = new HashSet<Partner>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
    }
}
