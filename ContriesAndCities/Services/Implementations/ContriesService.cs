namespace ContriesAndCities.Services.Implementations
{
    using ContriesAndCities.Data;
    using ContriesAndCities.Data.Models;
    using ContriesAndCities.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ContriesService : IContriesService
    {
        private readonly ApplicationDbContext db;
        private readonly ICitiesService citiesService;

        public ContriesService(ApplicationDbContext db,
            ICitiesService citiesService)
        {
            this.db = db;
            this.citiesService = citiesService;
        }

        public async Task AddCountry(string name)
        {
            if (!this.db.Countries.Any(c => c.Name == name))
            {
                var country = new Country
                {
                    Name = name,
                };

                await this.db.Countries.AddAsync(country);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<CountryViewModel> CountyById(int id)
        {
            return await this.db.Countries.Where(c => c.Id == id).Select(c => new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<CountryViewModel>> GetAllContries()
        {
            return await this.db.Countries.Select(c => new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
              .OrderBy(x => x.Name)
              .ToListAsync();
        }
    }
}
