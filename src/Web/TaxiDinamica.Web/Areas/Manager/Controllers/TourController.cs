namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Common;
    using TaxiDinamica.Services.Cloudinary;
    using TaxiDinamica.Services.Data.Directions;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.Schedules;
    using TaxiDinamica.Services.Data.Tours;
    using TaxiDinamica.Web.ViewModels.Directions;
    using TaxiDinamica.Web.ViewModels.Partners;
    using TaxiDinamica.Web.ViewModels.Schedules;
    using TaxiDinamica.Web.ViewModels.Tours;

    public class TourController : ManagerBaseController
    {
        private readonly IPartnersService partnersService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IToursService toursService;
        private readonly ISchedulesService schedulesService;
        private readonly IDirectionsService directionsService;

        public TourController(IPartnersService partnersService, ICloudinaryService cloudinaryService, IToursService toursService, ISchedulesService schedulesService, IDirectionsService directionsService)
        {
            this.partnersService = partnersService;
            this.cloudinaryService = cloudinaryService;
            this.toursService = toursService;
            this.schedulesService = schedulesService;
            this.directionsService = directionsService;
        }

        public async Task<IActionResult> AddTour(string id)
        {
            var partner = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (partner == null)
            {
                return new StatusCodeResult(404);
            }

            var tourViewModel = await this.toursService.GetAllByPartnerAsync<TourViewModel>(id);

            // Tour
            var viewModel = new TourInputModel()
            {
                Id = 0,
                PartnerId = id,
            };

            var directionsList = new List<DirectionInputModel>();
            int countDirections = 0;

            if (tourViewModel != null && tourViewModel.Count() > 0)
            {
                viewModel.Id = tourViewModel.First().Id;
                viewModel.TourStartTime = tourViewModel.First().TourStartTime;
                viewModel.TourEndTime = tourViewModel.First().TourEndTime;
                viewModel.TourStartAddress = tourViewModel.First().TourStartAddress;
                viewModel.TourEndAddress = tourViewModel.First().TourEndAddress;
                viewModel.DocTourUrl = tourViewModel.First().DocTourUrl;
                viewModel.TourType = tourViewModel.First().IsNormalTour ? "Normal" : "Varios";

                if (viewModel.TourType != "Normal")
                {
                    // Directions
                    var directionsViewModel = await this.directionsService.GetAllByTourAsync<DirectionViewModel>(tourViewModel.First().Id);

                    countDirections = directionsViewModel.Count();

                    foreach (var direction in directionsViewModel)
                    {
                        directionsList.Add(new DirectionInputModel()
                        {
                            Id = direction.Id,
                            Address = direction.Address,
                            EstimatedStartTime = direction.EstimatedStartTime,
                            EstimatedEndTime = direction.EstimatedEndTime,
                            TourId = direction.TourId,
                        });
                    }
                }
            }

            // Add Default Directions
            for (int i = 0; i < 7 - countDirections; i++)
            {
                directionsList.Add(new DirectionInputModel()
                {
                    Id = 0,
                    Address = string.Empty,
                });
            }

            viewModel.DirectionsList = directionsList;

            // Schedules
            var schedulesViewModel = await this.schedulesService.GetAllByPartnerAsync<ScheduleViewModel>(id);

            List<Tuple<string, bool>> daysOfWeek = new List<Tuple<string, bool>>();

            var culture = new System.Globalization.CultureInfo("es-ES");

            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Monday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Monday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Friday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Friday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday))));
            daysOfWeek.Add(new Tuple<string, bool>(culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday), schedulesViewModel.Any(x => x.Day == culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday))));

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

            var schedulesViewModel = await this.schedulesService.GetAllByPartnerAsync<ScheduleViewModel>(input.PartnerId);

            // Delete Schedules
            foreach (var schedule in schedulesViewModel)
            {
                await this.schedulesService.DeleteAsync(schedule.Id);
            }

            // Add Schedules
            foreach (var day in input.DaysOfWeek)
            {
                await this.schedulesService.AddAsync(day, input.PartnerId);
            }

            // Add DocTour
            string docTourUrl;

            try
            {
                if (input.DocTour != null)
                {
                    docTourUrl = await this.cloudinaryService.UploadPictureAsync(input.DocTour, input.PartnerId);
                }
                else
                {
                    docTourUrl = GlobalConstants.Images.DemoImg;
                }
            }
            catch (Exception)
            {
                docTourUrl = GlobalConstants.Images.DemoImg;
            }

            int tourId;

            if (input.Id == 0)
            {
                // Add Tour
                tourId = await this.toursService.AddAsync(input.TourStartTime.Value, input.TourEndTime.Value, input.TourStartAddress, input.TourEndAddress, docTourUrl, input.TourType == "Normal", input.PartnerId);
            }
            else
            {
                // Edit Tour
                tourId = await this.toursService.EditAsync(input.Id, input.TourStartTime.Value, input.TourEndTime.Value, input.TourStartAddress, input.TourEndAddress, docTourUrl, input.TourType == "Normal", input.PartnerId);
            }

            if (input.TourType != "Normal")
            {
                foreach (var direction in input.DirectionsList)
                {
                    if (direction.Address != null && direction.EstimatedStartTime != null && direction.EstimatedEndTime != null)
                    {
                        if (direction.Id == 0)
                        {
                            // Add Directions
                            await this.directionsService.AddAsync(direction.Address, direction.EstimatedStartTime.Value, direction.EstimatedEndTime.Value, tourId);
                        }
                        else
                        {
                            // Edit Directions
                            await this.directionsService.EditAsync(direction.Id, direction.Address, direction.EstimatedStartTime.Value, direction.EstimatedEndTime.Value, tourId);
                        }
                    }
                }
            }

            return this.RedirectToAction("Details", "Partners", new { id = input.PartnerId });
        }

    }
}
