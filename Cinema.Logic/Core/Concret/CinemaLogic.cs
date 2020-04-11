using AutoMapper;
using Cinema.Logic.Core.Abstract;
using Cinema.Logic.DTO;
using Cinema.Logic.Mapper.Abstract;
using Cinema.Logic.Mapper.Concret;
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
        private readonly CinemaMapper cinemaMapper;
        public CinemaLogic(IUnitOfWork unitOfWork,CinemaMapper cinemaMapper)
        {
            this.unitOfWork = unitOfWork;
            this.cinemaMapper = cinemaMapper;
        }
        public IQueryable<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> cinemaList = new List<CinemaDTO>();
            var cinemas = unitOfWork.cinemaRepository.Get();
            if (cinemas != null)
            {
                cinemaList = cinemaMapper.Mapper.Map<List<CinemaDTO>>(cinemas);
                return cinemaList.AsQueryable();
            }
            return cinemaList.AsQueryable();
        }
        public async Task<CinemaDTO> SetCinema(CinemaDTO cinema)
        {
            Cinema.Model.Entity.Cinema cinemaEntity = cinemaMapper.Mapper.Map<Cinema.Model.Entity.Cinema>(cinema);
            unitOfWork.cinemaRepository.Add(cinemaEntity);
            await unitOfWork.CommitAsync();
            cinema = cinemaMapper.Mapper.Map<CinemaDTO>(cinemaEntity);
            return cinema;
        }
    }
}
