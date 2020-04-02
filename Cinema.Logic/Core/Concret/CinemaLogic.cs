using AutoMapper;
using Cinema.Logic.Core.Abstract;
using Cinema.Logic.DTO;
using Cinema.Model.RepositoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Logic.Core.Concret
{
    public class CinemaLogic : ICinemaLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CinemaLogic(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public IQueryable<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> cinemaList = null;
            var cinemas = unitOfWork.cinemaRepository.Get();
            if (cinemas != null)
            {
                cinemaList = mapper.Map<List<CinemaDTO>>(cinemas);
            }
            return cinemaList.AsQueryable();
        }
        public async Task<CinemaDTO> SetCinema(CinemaDTO cinema)
        {
            Cinema.Model.Entity.Cinema cinemaEntity = mapper.Map<Cinema.Model.Entity.Cinema>(cinema);
            unitOfWork.cinemaRepository.Add(cinemaEntity);
            await unitOfWork.CommitAsync();
            cinema = mapper.Map<CinemaDTO>(cinemaEntity);
            return cinema;
        }
    }
}
