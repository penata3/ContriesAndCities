namespace ContriesAndCities.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CityInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "City name is too short")]
        [MaxLength(20,ErrorMessage = "City name is too long")]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
