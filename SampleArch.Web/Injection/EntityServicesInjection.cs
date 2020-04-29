using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SampleArch.Services;

namespace SampleArch.Web.Injection
{
    public static  class EntityServicesInjection
    {
        public static IServiceCollection AddEntityServicesInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICountryService, CountryService>();

            return services;
        }

    }
}
