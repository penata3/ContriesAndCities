﻿namespace ContriesAndCities.Controllers
{
    using ContriesAndCities.Models;
    using ContriesAndCities.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }
        
        public IActionResult Add()
        {
            var model = new CityInputModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CityInputModel model,int countryId)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var sss = string.Empty;
          

            await this.citiesService.AddCity(model.Name, countryId);

            return this.RedirectToAction("All", "Countries");
        }
    }
}