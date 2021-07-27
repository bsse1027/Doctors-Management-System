using DoctorManagement.Data;
using DoctorManagement.Interfaces;
using DoctorManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(

                        config.GetConnectionString("DefaultConnection")

                        );
                });

            return services;
        }
    }
}
