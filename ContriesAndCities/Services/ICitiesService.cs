namespace ContriesAndCities.Services
{
    using ContriesAndCities.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICitiesService
    {
        Task<IEnumerable<CityViewModel>> GetAllCitiesForGivenCountry(int countryId);

        Task AddCity(string name, int countyId);
    }
}
