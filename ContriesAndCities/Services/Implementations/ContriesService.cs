using ContriesAndCities.Data;
using ContriesAndCities.Data.Models;
using ContriesAndCities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContriesAndCities.Services.Implementations
{
    public class ContriesService : IContriesService
    {
        private readonly ApplicationDbContext db;

        public ContriesService(ApplicationDbContext db)
        {
            this.db = db;
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

        public async Task<CountryInListViewModel> CountyById(int id)
        {
           return  await this.db.Countries.Where(c => c.Id == id).Select(c => new CountryInListViewModel
            {
                Id = c.Id,
                Name = c.Name,

            }).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<CountryInListViewModel>> GetAllContries()
        {
            return await this.db.Countries.Select(c => new CountryInListViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
                .ToListAsync();
        }
    }
}
