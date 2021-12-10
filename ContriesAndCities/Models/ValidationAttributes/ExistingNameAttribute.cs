namespace ContriesAndCities.Models.ValidationAttributes
{
    using ContriesAndCities.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ExistingNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value.ToString();
            var db = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            if (db.Cities.Any(c => c.Name == valueAsString) || db.Countries.Any(c => c.Name == valueAsString))
            {
                return new ValidationResult("The name already exists try another one!");
            }

            return ValidationResult.Success;
        }
    }
}
