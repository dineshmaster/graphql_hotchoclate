using Cinema.Logic.Core.Abstract;
using Cinema.Logic.DTO;
using Cinema.Model.RepositoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Logic.Core.Concret
{
    public class CinemaLogic : ICinemaLogic
    {
        private readonly IUnitOfWork unitOfWork;
        public CinemaLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IQueryable<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> cinemaList = null;
            var cinemas = unitOfWork.cinemaRepository.Get();
            if (cinemas != null)
            {
                cinemaList = new List<CinemaDTO>();
                foreach(var item in cinemas)
                {
                    cinemaList.Add(new CinemaDTO
                    {
                        Description = item.Description,
                        Duration = item.Duration,
                        ID = item.ID,
                        Title = item.Title
                    });
                }
            }
            return cinemaList.AsQueryable();
        }
    }
}
