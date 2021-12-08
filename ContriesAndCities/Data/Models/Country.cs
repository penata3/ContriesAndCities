namespace ContriesAndCities.Data.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; } = new HashSet<City>();
    }
}
