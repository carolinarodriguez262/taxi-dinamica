﻿namespace TaxiDinamica.Web.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;

    public class CityInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }
    }
}
