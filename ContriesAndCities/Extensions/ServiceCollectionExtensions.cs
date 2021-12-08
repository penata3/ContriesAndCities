namespace ContriesAndCities.Extensions
{
    using ContriesAndCities.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration  configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }


        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }
            )
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
