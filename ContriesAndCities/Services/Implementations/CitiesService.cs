namespace ContriesAndCities.Services.Implementations
{
    using ContriesAndCities.Data;
    using ContriesAndCities.Data.Models;
    using ContriesAndCities.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CitiesService : ICitiesService
    {
        private readonly ApplicationDbContext db;

        public CitiesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddCity(string name, int countyId)
        {
            if (!this.db.Cities.Any(c => c.Name == name) && !this.db.Countries.Any(c => c.Name == name))
            {
                var city = new City
                {
                    Name = name,
                    CountryId = countyId
                };

                await this.db.Cities.AddAsync(city);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CityViewModel>> GetAllCitiesForGivenCountry(int countryId)
        {
            return await this.db.Cities.Where(c => c.CountryId == countryId)
                   .Select(c => new CityViewModel
                   {
                       Id = c.Id,
                       Name = c.Name,
                   })
                   .ToListAsync();
        }
    }
}
