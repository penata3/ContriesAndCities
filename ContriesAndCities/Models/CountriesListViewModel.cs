namespace ContriesAndCities.Models
{
    using System.Collections.Generic;

    public class CountriesListViewModel
    {
        public IEnumerable<CountryInListViewModel> Contries { get; set; }
    }
}
