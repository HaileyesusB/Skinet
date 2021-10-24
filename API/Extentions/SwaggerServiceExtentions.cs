using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extentions
{
    public static class SwaggerServiceExtentions   //because its value will not be changed
    {
        public static IServiceCollection AddSwaggerCollections(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("V1", new OpenApiInfo { Title = "Skinet API", Version = "v1" });
                });
            return services;
        }


    }
}
