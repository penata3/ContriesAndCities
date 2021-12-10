namespace ContriesAndCities.Models
{
    using System.Collections.Generic;

    public class CountryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }
    }
}
