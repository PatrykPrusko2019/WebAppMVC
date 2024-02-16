using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mappings;
using WebAppMVC.Application.Services;

namespace WebAppMVC.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILeagueService, LeagueService>();

            services.AddAutoMapper(typeof(LeagueMappingProfile));
        }
    }
}
