namespace ContriesAndCities.Controllers
{
    using ContriesAndCities.Models;
    using ContriesAndCities.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }
        
        [Authorize]
        public IActionResult Add()
        {
            var model = new CityInputModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CityInputModel model,int countryId)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
         
            await this.citiesService.AddCity(model.Name, countryId);

            return this.RedirectToAction("Details", "Countries", new { @id = countryId });
        }
    }
}
