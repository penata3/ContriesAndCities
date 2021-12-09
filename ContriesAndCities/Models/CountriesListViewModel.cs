namespace ContriesAndCities.Models
{
    using System.Collections.Generic;

    public class CountriesListViewModel : PaginationViewModel
    {
        public IEnumerable<CountryViewModel> Contries { get; set; }
    }
}
