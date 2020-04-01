using Cinema.Logic.Core.Abstract;
using Cinema.Logic.DTO;
using Cinema.Model.RepositoryCore;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Service.Query
{
    [ExtendObjectType(Name = "Query")]
    public class CinemaQuery
    {
        [UseFiltering]
        [UseSorting]
        [UsePaging]
        public IQueryable<CinemaDTO> GetCinemas([Service]ICinemaLogic cinemaLogic)
        {
            var cinemas = cinemaLogic.GetCinemas();
            return cinemas.AsQueryable();
        }
    }
}
