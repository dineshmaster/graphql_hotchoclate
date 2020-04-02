using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cinema.Service.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class CinemaMutation
    {
        public Cinema.Model.Entity.Cinema CreateCinema(CinemaInput cinemaInput,CancellationToken cancellationtoken)
        {
            return new Model.Entity.Cinema();
        }
    }
}
