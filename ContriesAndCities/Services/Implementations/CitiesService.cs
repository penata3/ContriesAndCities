namespace ContriesAndCities.Services.Implementations
{
    using AutoMapper;
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
        private readonly IMapper mapper;

        public CitiesService(
            ApplicationDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddCity(string name, int countyId)
        {
            var city = new City
            {
                Name = name,
                CountryId = countyId
            };

            await this.db.Cities.AddAsync(city);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CityViewModel>> GetAllCitiesForGivenCountry(int countryId)
        {
            return await this.db.Cities.Where(c => c.CountryId == countryId)
                .Select(c => this.mapper.Map<CityViewModel>(c))
                   .ToListAsync();
        }

        public int GetCountOfCitiesForGivenCountry(int counryId)
        {
            return this.db.Cities.Where(c => c.CountryId == counryId).Count();
        }
    }
}
