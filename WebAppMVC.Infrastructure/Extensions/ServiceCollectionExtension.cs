using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Infrastructure.Persistence;
using WebAppMVC.Infrastructure.Repository;
using WebAppMVC.Infrastructure.Seeders;

namespace WebAppMVC.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebAppMVCDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("WebAppMVCDbContext"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<WebAppMVCDbContext>();

            services.AddScoped<FootballTeamSeeder>();

            services.AddScoped<ILeagueRepository, LeagueRepository>();
        }
    }
}
