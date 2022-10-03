namespace TaxiDinamica.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.Tours;
    using TaxiDinamica.Web.ViewModels.Categories;
    using TaxiDinamica.Web.ViewModels.Common.Pagination;
    using TaxiDinamica.Web.ViewModels.Partners;
    using TaxiDinamica.Web.ViewModels.Tours;

    public class PartnersController : BaseController
    {
        private readonly IPartnersService partnersService;
        private readonly ICategoriesService categoriesService;
        private readonly IToursService toursService;

        public PartnersController(
            IPartnersService partnersService,
            ICategoriesService categoriesService,
            IToursService toursService)
        {
            this.partnersService = partnersService;
            this.categoriesService = categoriesService;
            this.toursService = toursService;
        }

        public async Task<IActionResult> Index(
            int? sortId, // categoryId
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (sortId != null)
            {
                var category = await this.categoriesService
                    .GetByIdAsync<CategorySimpleViewModel>(sortId.Value);
                if (category == null)
                {
                    return new StatusCodeResult(404);
                }

                this.ViewData["CategoryName"] = category.Name;
            }

            this.ViewData["CurrentSort"] = sortId;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.ViewData["CurrentFilter"] = searchString;

            int pageSize = PageSizesConstants.Partners;
            var pageIndex = pageNumber ?? 1;

            var partners = await this.partnersService
                .GetAllWithSortingFilteringAndPagingAsync<PartnerViewModel>(searchString, sortId, pageSize, pageIndex);
            var partnersList = partners.ToList();

            // Add Tour
            foreach (var partner in partnersList)
            {
                var tours = await this.toursService.GetAllByPartnerAsync<TourViewModel>(partner.Id);

                if (tours.Count() > 0)
                {
                    partner.TourViewModel = tours.First();
                }
                else
                {
                    partner.TourViewModel = new TourViewModel()
                    {
                        IsNormalTour = true,
                    };
                }
            }

            var count = await this.partnersService
                .GetCountForPaginationAsync(searchString, sortId);

            var viewModel = new PartnersPaginatedListViewModel
            {
                Partners = new PaginatedList<PartnerViewModel>(partnersList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }
    }
}
