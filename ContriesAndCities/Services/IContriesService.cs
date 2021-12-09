namespace ContriesAndCities.Services
{
    using ContriesAndCities.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContriesService
    {
       Task<IEnumerable<CountryViewModel>> GetAllContries();

        Task AddCountry(string name);

        Task<CountryViewModel> CountyById(int id);
    }
}
