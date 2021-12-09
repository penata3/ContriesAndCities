namespace ContriesAndCities.Controllers
{
    using ContriesAndCities.Models;
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

        public async Task<IActionResult> All()
        {
            var countries = new CountriesListViewModel
            {
                Contries = await this.contriesService.GetAllContries(),
            };
            
            return this.View(countries);
        }

        [Authorize]
        public IActionResult Add() 
        {
            var input = new CountryViewModel();
            return this.View(input);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CountryViewModel model)
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
