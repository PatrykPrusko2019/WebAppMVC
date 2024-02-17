using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.League.Commands.CreateLeague;
using WebAppMVC.Application.Mappings;

namespace WebAppMVC.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateLeagueCommand));

            services.AddAutoMapper(typeof(LeagueMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateLeagueCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
