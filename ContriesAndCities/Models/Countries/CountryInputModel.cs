namespace ContriesAndCities.Models.Countries
{
    using ContriesAndCities.Models.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;

    public class CountryInputModel
    {
        [Required]
        [ExistingName]
        [MinLength(3, ErrorMessage = "Country name is too short")]
        [MaxLength(20, ErrorMessage = "Country name is too long")]
        public string Name { get; set; }
    }
}
