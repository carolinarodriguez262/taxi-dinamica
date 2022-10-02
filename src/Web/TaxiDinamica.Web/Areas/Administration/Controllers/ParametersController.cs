namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Parameters;
    using TaxiDinamica.Web.ViewModels.Parameters;

    public class ParametersController : AdministrationController
   {
        private IParametersService parametersService;

        public ParametersController(IParametersService parametersService)
        {
            this.parametersService = parametersService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ParametersListViewModel
            {
                Parameters = await this.parametersService.GetAllAsync<ParameterViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
