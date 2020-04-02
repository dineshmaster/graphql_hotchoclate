using AutoMapper;
using Cinema.Logic.Core.Abstract;
using Cinema.Logic.DTO;
using HotChocolate;
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
        public async Task<CinemaDTO> CreateCinema(CinemaInput cinemaInput,
            [Service]ICinemaLogic cinemaLogic,
            [Service]IMapper mapper, CancellationToken cancellationtoken)
        {
            CinemaDTO inputCinema = mapper.Map<CinemaDTO>(cinemaInput);
            CinemaDTO cinemaDTO = await cinemaLogic.SetCinema(inputCinema);
            return cinemaDTO;
        }
    }
}
