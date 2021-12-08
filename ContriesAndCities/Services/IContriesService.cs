namespace ContriesAndCities.Services
{
    using ContriesAndCities.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContriesService
    {
       Task<IEnumerable<CountryInListViewModel>> GetAllContries();

        Task AddCountry(string name);

        Task<CountryInListViewModel> CountyById(int id);
    }
}
