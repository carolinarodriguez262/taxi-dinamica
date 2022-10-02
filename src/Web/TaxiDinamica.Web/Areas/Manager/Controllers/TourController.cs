using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiDinamica.Services.Data.Partners;
using TaxiDinamica.Web.ViewModels.Partners;
using TaxiDinamica.Web.ViewModels.Tours;

namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    public class TourController : ManagerBaseController
    {
        private readonly IPartnersService partnersService;

        public TourController(IPartnersService partnersService)
        {
            this.partnersService = partnersService;
        }

        public async Task<IActionResult> AddTour(string id)
        {
            var partner = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (partner == null)
            {
                return new StatusCodeResult(404);
            }

            var viewModel = new TourInputModel
            {
                PartnerId = id,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTour(TourInputModel input)
        {
            return this.View();
        }

    }
}
