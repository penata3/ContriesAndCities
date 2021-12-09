﻿namespace ContriesAndCities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CountryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }
    }
}