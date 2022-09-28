using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    public class TourController : ManagerBaseController
    {
        public async Task<IActionResult> AddTour()
        {
            return this.View();
        }
    }
}
