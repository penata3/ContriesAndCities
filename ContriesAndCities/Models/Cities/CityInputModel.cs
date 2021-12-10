namespace ContriesAndCities.Models
{
    using ContriesAndCities.Models.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;

    public class CityInputModel
    {
        [Required]
        [ExistingName]
        [MinLength(3, ErrorMessage = "City name is too short")]
        [MaxLength(20,ErrorMessage = "City name is too long")]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
