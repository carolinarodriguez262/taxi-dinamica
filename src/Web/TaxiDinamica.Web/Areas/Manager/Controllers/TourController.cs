using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiDinamica.Common;
using TaxiDinamica.Data.Models;
using TaxiDinamica.Services.Cloudinary;
using TaxiDinamica.Services.Data.Partners;
using TaxiDinamica.Services.Data.Schedules;
using TaxiDinamica.Services.Data.Tours;
using TaxiDinamica.Web.ViewModels.Directions;
using TaxiDinamica.Web.ViewModels.Partners;
using TaxiDinamica.Web.ViewModels.Tours;

namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    public class TourController : ManagerBaseController
    {
        private readonly IPartnersService partnersService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IToursService toursService;
        private readonly ISchedulesService schedulesService;

        public TourController(IPartnersService partnersService, ICloudinaryService cloudinaryService, IToursService toursService, ISchedulesService schedulesService)
        {
            this.partnersService = partnersService;
            this.cloudinaryService = cloudinaryService;
            this.toursService = toursService;
            this.schedulesService = schedulesService;
        }

        public async Task<IActionResult> AddTour(string id)
        {
            var partner = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (partner == null)
            {
                return new StatusCodeResult(404);
            }

            var directionsList = new List<DirectionInputModel>();

            for (int i = 0; i < 7; i++)
            {
                directionsList.Add(new DirectionInputModel()
                {
                    Address = string.Empty,
                });
            }

            var viewModel = new TourInputModel
            {
                PartnerId = id,
                DirectionsList = directionsList,
            };

            List<string> daysOfWeek = new List<string>();

            var culture = new System.Globalization.CultureInfo("es-ES");

            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Monday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Friday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday));
            daysOfWeek.Add(culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday));

            this.ViewData["DaysOfWeek"] = daysOfWeek;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTour(TourInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // Add Schedules
            foreach (var day in input.DaysOfWeek)
            {
                await this.schedulesService.AddAsync(day, input.PartnerId);
            }

            // Add Tour
            string docTourUrl;

            try
            {
                docTourUrl = await this.cloudinaryService.UploadPictureAsync(input.DocTourUrl,input.PartnerId);
            }
            catch (Exception)
            {
                docTourUrl = GlobalConstants.Images.DemoImg;
            }

            var tourId = await this.toursService.AddAsync(input.TourStartTime.Value, input.TourEndTime.Value, input.TourStartAddress, input.TourEndAddress, docTourUrl, input.TourType == "Normal", input.PartnerId);
            
            if (input.TourType != "Normal")
            {
                // Add Directions

            }


            return this.View(input);
        }

    }
}
