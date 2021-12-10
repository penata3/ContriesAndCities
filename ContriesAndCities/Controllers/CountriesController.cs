namespace ContriesAndCities.Controllers
{
    using ContriesAndCities.Models;
    using ContriesAndCities.Models.Countries;
    using ContriesAndCities.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CountriesController : Controller
    {
        private readonly IContriesService contriesService;
        private readonly ICitiesService citiesService;

        public CountriesController(
            IContriesService contriesService,
            ICitiesService citiesService)
        {
            this.contriesService = contriesService;
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> All(int id = 1)
        {

            const int ItemsPerPage = 6;
            var count = this.contriesService.GetCount();

            var model = new CountriesListViewModel
            {
                PageNumber = id,
                Contries = await this.contriesService.GetAllContries(id, ItemsPerPage),
                ItemsCount = this.contriesService.GetCount(),
                ItemsPerPage = ItemsPerPage,
                ActionName = nameof(this.All)
            };

            var it = string.Empty;
            return this.View(model);
        }

        [Authorize]
        public IActionResult Add() 
        {
            var input = new CountryInputModel();
            return this.View(input);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CountryInputModel model)
        {
            if (!this.ModelState.IsValid) 
            {
                return this.View(model);
            }

            await this.contriesService.AddCountry(model.Name);

            return this.RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await this.contriesService.CountyById(id);
            model.Cities = await this.citiesService.GetAllCitiesForGivenCountry(id);
            return this.View(model);
        }

        public IActionResult Count(int id = 2)
        {
            var model =  this.citiesService.GetAllCitiesForGivenCountry(id);
            return this.View(model);
        }
    }
}
