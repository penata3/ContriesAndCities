namespace ContriesAndCities
{
    using AutoMapper;
    using ContriesAndCities.Data.Models;
    using ContriesAndCities.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryViewModel>();   
            CreateMap<City, CityViewModel>();
        }
    }
}
