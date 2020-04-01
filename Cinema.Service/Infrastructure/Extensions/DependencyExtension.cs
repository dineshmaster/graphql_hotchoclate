using Cinema.Logic.Core.Abstract;
using Cinema.Logic.Core.Concret;
using Cinema.Model.CoreData;
using Cinema.Model.RepositoryCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.Infrastructure.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:CinemaConnection"]));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<ICinemaLogic, CinemaLogic>();
        }
    }
}
