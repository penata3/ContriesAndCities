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

    public class ContriesService : IContriesService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ContriesService(ApplicationDbContext db,
            IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddCountry(string name)
        {
            var country = new Country
            {
                Name = name,
            };

            await this.db.Countries.AddAsync(country);
            await this.db.SaveChangesAsync();
        }

        public async Task<CountryViewModel> CountyById(int id)
        {
            return await this.db.Countries.Where(c => c.Id == id)
                .Select(c => this.mapper.Map<CountryViewModel>(c))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CountryViewModel>> GetAllContries(int page, int itemsPerPage)
        {
            return await this.db.Countries
                .OrderBy(x => x.Name)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(c => this.mapper.Map<CountryViewModel>(c))
              .ToListAsync();
        }

        public int GetCount()
        {
            return this.db.Countries.Count();
        }
    }
}
