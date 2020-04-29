using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleArch.ORM;
using SampleArch.Repository.Abstracts;
using SampleArch.Repository.Interfaces;
using SampleArch.Services;

namespace SampleArch.Web.Injection
{
    public static  class EntityServicesInjection
    {
        public static IServiceCollection AddEntityServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }

    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SampleArchDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext>(sp => sp.GetRequiredService<SampleArchDbContext>());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
