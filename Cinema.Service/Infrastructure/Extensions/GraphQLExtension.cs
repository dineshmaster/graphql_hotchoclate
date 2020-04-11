
using Cinema.Service.Schema.Cinema;
using Cinema.Service.Schema.Hello;
using Cinema.Service.SChema.Cinema;
using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.Infrastructure.Extensions
{
    public static class GraphQLExtension
    {
        public static void AddCinemaGraphQL(this IServiceCollection services)
        {
            services.AddGraphQL(SchemaBuilder.New()
              .AddQueryType(p => p.Name("Query"))
              .AddType<CinemaQuery>()
              .AddType<HelloQuery>()
              .AddMutationType(p => p.Name("Mutation"))
              .AddType<CinemaMutation>()
              .Create()) ;
        }

        
    }
}
