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

        public CountriesController(IContriesService contriesService)
        {
            this.contriesService = contriesService;
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
            var input = new CountryInListViewModel();
            return this.View(input);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CountryInListViewModel model)
        {
            if (!this.ModelState.IsValid) 
            {
                return this.View(model);
            }

            await this.contriesService.AddCountry(model.Name);

            var id = string.Empty;


            return this.RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            var model = await this.contriesService.CountyById(id);

            return this.View(model);
        }
    }
}
