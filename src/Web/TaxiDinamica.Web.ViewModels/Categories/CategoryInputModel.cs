﻿namespace TaxiDinamica.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Web.ViewModels.Common.CustomValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class CategoryInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.DescriptionMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Description,
            MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
